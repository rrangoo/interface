using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace @interface
{
    public partial class GraphPage : UserControl
    {
        // С графиком надо работать через chart1.
        // подключить к нему коллекцию, которая будет отображаться.
        // как раз коллекцияэто и будет табличка.
        public GraphPage()
        {
            InitializeComponent();

            // Это якори для растяжки размеров экрана.
            Anchor = AnchorStyles.Right & AnchorStyles.Left & AnchorStyles.Top;
            chart1.DataSource = null;
        }
    }
}
