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
            selectFormat.Items.Add("JSON");
            selectFormat.Items.Add("XML");
            selectFormat.Items.Add("BINARY");
            selectFormat.SelectedIndex = 0;
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
            if (tree.tree.Count == 0)
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

        private string GetSelectedFormat()
        {
            return selectFormat.SelectedItem.ToString().ToLower();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получаем выбранный формат из ComboBox
            string format = GetSelectedFormat();

            // Получаем путь к файлу через SaveFileDialog
            string filePath = GetSaveFilePath(format);

            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    tree.SaveCollectionToFile(filePath, format);
                    MessageBox.Show("Коллекция успешно сохранена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetSaveFilePath(string format)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Сохранить файл",
                Filter = GetFileFilter(format),
                DefaultExt = GetDefaultExtension(format)
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return null; // Если пользователь отменил выбор
        }

        private string GetFileFilter(string format)
        {
            return format.ToLower() switch
            {
                "json" => "JSON Files (*.json)|*.json|All Files (*.*)|*.*",
                "xml" => "XML Files (*.xml)|*.xml|All Files (*.*)|*.*",
                "binary" => "Binary Files (*.dat)|*.dat|All Files (*.*)|*.*",
                _ => "All Files (*.*)|*.*"
            };
        }

        private string GetDefaultExtension(string format)
        {
            return format.ToLower() switch
            {
                "json" => ".json",
                "xml" => ".xml",
                "binary" => ".dat",
                _ => ""
            };
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            // Получаем выбранный формат из ComboBox
            string format = GetSelectedFormat();

            // Получаем путь к файлу через OpenFileDialog
            string filePath = GetOpenFilePath(format);

            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    tree.LoadCollectionFromFile(filePath, format);
                    MessageBox.Show("Коллекция успешно загружена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string GetOpenFilePath(string format)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Выберите файл",
                Filter = GetFileFilter(format)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return null; // Если пользователь отменил выбор
        }
    }
}
