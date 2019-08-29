using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using BusinessLogicContracts.Interfaces;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public class ListViewModel : ReactiveObject
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private readonly ObservableAsPropertyHelper<IEnumerable<ContentBaseViewModel>> _contentList;

        private ContentFolderViewModel selectedFolder;

        private ContentBaseViewModel selectedItem;

        public ListViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();

            _contentList = this
                .WhenAnyValue(x => x.SelectedFolder)
                .Where(o => !ObjectIsNull(o))
                .Select(t => GetContentList(t.Id))
                .ToProperty(this, x => x.ContentList);
        }

        public IEnumerable<ContentBaseViewModel> ContentList => _contentList.Value;

        public ContentBaseViewModel SelectedItem
        {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
        }

        public ContentFolderViewModel SelectedFolder
        {
            get => selectedFolder;
            set => this.RaiseAndSetIfChanged(ref selectedFolder, value);
        }

        private IEnumerable<ContentBaseViewModel> GetContentList(int id)
        {
            var item = contentBaseService.GetContentItemById(id);
            var list = viewModelFactory.GetViewModels(item.Children, selectedFolder);

            return new List<ContentBaseViewModel>(list);
        }

        private bool ObjectIsNull(object obj)
        {
            bool result = true;

            if (obj != null)
            {
                result = false;
            }

            return result;
        }
    }
}
