using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab15_ver2
{
    public partial class Form1 : Form
    {
        private Button[] buttons = new Button[3]; // ������ ������
        private RaceManager raceManager; // ��������� RaceManager

        public Form1()
        {
            InitializeComponent();
            InitializeUI();

            raceManager = new RaceManager();
            raceManager.PositionUpdated += OnPositionUpdated; // ������������� �� ������� ���������� �������
        }

        private void InitializeUI()
        {
            this.Text = "��������� ����";
            this.Size = new Size(1920, 400);

            // �������� ������
            for (int i = 0; i < 3; i++)
            {
                buttons[i] = new Button
                {
                    Text = $"������ {i + 1}",
                    Location = new Point(10, 50 + i * 60),
                    Size = new Size(100, 40)
                };
                this.Controls.Add(buttons[i]);
            }

            // ������ "�����"
            var startButton = new Button
            {
                Text = "�����",
                Location = new Point(10, 250),
                Size = new Size(100, 40)
            };
            startButton.Click += StartRace;
            this.Controls.Add(startButton);

            // ������ "�����"
            var resetButton = new Button
            {
                Text = "�����",
                Location = new Point(120, 250),
                Size = new Size(100, 40)
            };
            resetButton.Click += ResetPositions;
            this.Controls.Add(resetButton);

            
            for (int i = 0; i < 3; i++)
            {
                int index = i; 
                var trackBar = new TrackBar
                {
                    Location = new Point(120, 50 + i * 60),
                    Size = new Size(200, 40),
                    Minimum = 1,
                    Maximum = 10,
                    Value = 5
                };
                trackBar.ValueChanged += (s, e) => UpdatePriority(index, trackBar.Value);
                this.Controls.Add(trackBar);
            }
        }

        
        private void StartRace(object sender, EventArgs e)
        {
            raceManager.StartRace();
        }

        // ����� ������� ������
        private void ResetPositions(object sender, EventArgs e)
        {
            raceManager.ResetRace();

            
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Invoke((MethodInvoker)(() =>
                {
                    buttons[i].Location = new Point(10, buttons[i].Location.Y);
                }));
            }

            
            MessageBox.Show("����� ��������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ���������� ���������� ������
        private void UpdatePriority(int index, int value)
        {
            raceManager.UpdatePriority(index, value);
        }

        // ��������� ������� ���������� �������
        private void OnPositionUpdated(int index)
        {
            buttons[index].Invoke((MethodInvoker)(() =>
            {
                int x = raceManager.GetPosition(index);
                buttons[index].Location = new Point(x, buttons[index].Location.Y);
            }));
        }
    }
}