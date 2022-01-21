using System.Windows.Forms;

namespace @interface
{
    public partial class TablePage : UserControl
    {
        // В конструкторе принимает имя.
        public TablePage(string tableName)
        {
            InitializeComponent();

            // Это якори для растяжки размеров экрана.
            Anchor = AnchorStyles.Right & AnchorStyles.Left & AnchorStyles.Top;

            headerLabel.Text = tableName;
        }
    }
}
