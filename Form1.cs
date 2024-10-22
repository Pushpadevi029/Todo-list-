namespace Todo_list
{
    public partial class Form1 : Form
    {
        private List<Task> tasks = new List<Task>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string description = textBox2.Text;

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description))
            {
                Task task = new Task(title, description);
                tasks.Add(task);
                listBox1.Items.Add(task.Title + "-" + task.Description);
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Please enter both title and description.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int index = listBox1.SelectedIndex;
                tasks.RemoveAt(index);
                listBox1.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Please select a task.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int index = listBox1.SelectedIndex;
                tasks[index].Completed = true;
                listBox1.Items[index] = tasks[index].Title + " (Completed)";
            }
            else
            {
                MessageBox.Show("Please select a task.");
            }
        }
        public class Task
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public bool Completed { get; set; }

            public Task(string title, string description)
            {
                Title = title;
                Description = description;
                Completed = false;
            }
        }
    }
}
