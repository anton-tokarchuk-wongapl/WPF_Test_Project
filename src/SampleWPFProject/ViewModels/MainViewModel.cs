using SampleWPFProject.DBContext;
using SampleWPFProject.Models;

namespace SampleWPFProject.ViewModels
{
    public class MainViewModel : BaseVM
    {
        private readonly DataBase db;

        private readonly TreeViewModel treeViewModel;

        private ListViewModel listViewModel;

        private TextBlockViewModel textBlockViewModel;

        public MainViewModel()
        {
            db = DataBase.GetInstance();
            treeViewModel = new TreeViewModel();
            treeViewModel.FoldersList = db.FoldersCollection;
            listViewModel = new ListViewModel();
            textBlockViewModel = new TextBlockViewModel();
        }

        public TreeViewModel TreeViewModel 
            => treeViewModel;

        public ListViewModel ListViewModel 
            => listViewModel;

        public TextBlockViewModel TextBlockViewModel
            => textBlockViewModel;
    }
}