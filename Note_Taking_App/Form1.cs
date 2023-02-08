using System.Data;

namespace Note_Taking_App
{
    public partial class Form1 : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");
            previousNotes.DataSource = notes;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txbTitle.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            txbNote.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Not a valid note");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = txbTitle.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = txbNote.Text;
            }
            else 
            {
                notes.Rows.Add(txbTitle.Text, txbNote.Text);
            }
            txbTitle.Text = "";
            txbNote.Text = "";
            editing = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txbTitle.Text = "";
            txbNote.Text = "";
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txbTitle.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            txbNote.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}