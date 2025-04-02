using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing;

namespace Lab16
{
    public partial class Form1 : Form
    {
        TreeManager tree = new TreeManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void generateCollection_Click(object sender, EventArgs e)
        {
            int count;
            bool isCorrect = int.TryParse(inputCount.Text, out count);
            if (!isCorrect)
            {
                MessageBox.Show("Введите корректное целое число", "Ошибка генерации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tree.FillCollection(count);
                MessageBox.Show("Коллекция успешно сгенерирована", "Успешная генерация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void DisplayCollectionInListBox()
        {
            if(tree.tree.Count == 0)
            {
                MessageBox.Show("Коллекция пуста", "Ошибка вывода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                output.Items.Clear();
                foreach (var item in tree.tree)
                {
                    output.Items.Add(item.ToString());
                }
            }
            

        }

        private void showCollection_Click(object sender, EventArgs e)
        {
            DisplayCollectionInListBox();
        }
    }
}
