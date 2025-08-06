using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DataBinding
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _boundText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string BoundText
        {
            get { return _boundText; }
            set { 
                _boundText = value;
                // when using OnPropChange() we do not have to relay on GUI to finish logic and vice versa
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BoundText"));
                
                // We could also create method an use like this
                //OnPropertyChanged("BoundText");
                OnPropertyChanged(); // because of using [CallerMemberName] we do not have to pass args as will automatically populate with the caller name for us based on the caller, so if BasedText is the one calling the OnPropertyChanged(); method
            }
        }

        public MainWindow()
        {
            DataContext = this; // DataContext is setting default where the data binding is going to look, which is in our case whole MainWindow class. That why we write in the constructor
            InitializeComponent();
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            BoundText = "set from code.";
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}