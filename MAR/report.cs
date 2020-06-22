using System.Drawing;
using System.Windows.Forms;

namespace MAR
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"Res\1.jpg");
            pictureBox2.Image = Image.FromFile(@"Res\2.jpg");
        }
    }
}