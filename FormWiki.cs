using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;
/*Dongyun Huang 30042104
 29/3/2023

The Wiki Application to demonstrate how a collection of information can be stored using a Windows Application (WinForms). 
This application will utilise a List<T> of a class object
 */
namespace WikiData
{
    public partial class FormWiki : Form
    {
        public FormWiki()
        {
            InitializeComponent();
        }
        // 6.2 Create a global List<T> of type Information called Wiki.
        List<Information> wiki = new List<Information>();

        #region ADD/DELETE/EDIT
        // 6.3 Create a button method to ADD a new item to the list.Use a TextBox for the Name input,
        // ComboBox for the Category, Radio group for the Structure and Multiline TextBox for the Definition. 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            stsMsglbl.Text = "";
            Information addData = new Information();
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                bool isValid = ValidName(txtName.Text); // Calling ValidName method.
                if (isValid)
                {
                    addData.setName(txtName.Text);
                    addData.setCategory(cboCategory.Text);
                    addData.setStructure(getStructure());
                    addData.setDefinition(txtDefinition.Text);
                    wiki.Add(addData);
                    stsMsglbl.Text = "Successfully added";
                    DisplayData();
                    ClearResetInput();
                }
                else
                {
                    stsMsglbl.Text = "Add failed, duplicata name";
                }
            }
            else
            {
                stsMsglbl.Text = "Please enter a name...";
            }

        }

        // 6.7 Create a button method that will delete the currently selected record in the ListView.
        // Ensure the user has the option to backout of this action by using a dialog box.
        // Display an updated version of the sorted list at the end of this process. 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            stsMsglbl.Text = "";
            try
            {
                int selectedIndex = lvDisplay.SelectedIndices[0];
                DialogResult result = MessageBox.Show("Do you want to delete the record?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    wiki.RemoveAt(selectedIndex);
                    stsMsglbl.Text = "Successfully deleted";
                    DisplayData();
                    ClearResetInput();
                }
            }
            catch
            {
                stsMsglbl.Text = "Please select a record to be deleted..";
            }
        }
        // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView.
        // All the changes in the input controls will be written back to the list.
        // Display an updated version of the sorted list at the end of this process. 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Get the selected item in the ListView control
            ListViewItem selectedItem = lvDisplay.SelectedItems[0];

            // Get the new values from the input controls
            string name = txtName.Text.ToLower().Trim();

            // Check if the new name is already in use by another item
            bool isDuplicate = false;
            foreach (ListViewItem item in lvDisplay.Items)
            {
                if (item != selectedItem && item.SubItems[0].Text == name) // Exclusive the selected item
                {
                    isDuplicate = true;
                    break;
                }
            }

            try
            {
                // If the name is not a duplicate, update the selected item
                if (!isDuplicate)
                {
                    int selectedIndex = lvDisplay.SelectedIndices[0];
                    Information editData = new Information();

                    editData.setName(txtName.Text);
                    editData.setCategory(cboCategory.Text);
                    editData.setStructure(getStructure());
                    editData.setDefinition(txtDefinition.Text);

                    wiki[selectedIndex] = editData; // Replace obj.
                    stsMsglbl.Text = "Successfully edited";
                    DisplayData();
                    ClearResetInput();
                }
                else
                {
                    stsMsglbl.Text = "Edit failed, duplicata name";
                }
            }
            catch
            {
                stsMsglbl.Text = "Please select a record to be edited..";
            }
        }
        #endregion

        #region  BUILTIN BINARY SEARCH
        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        // If the record is found the associated details will populate the appropriate input controls
        // and highlight the name in the ListView. At the end of the search process the search input TextBox must be cleared.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            stsMsglbl.Text = "";
            if (string.IsNullOrEmpty(txtSearch.Text)) // Check user empty input.
            {
                stsMsglbl.Text = "Please enter a data structure name";
                return;
            }
            Information searchData = new Information();  // Create object.
            searchData.setName(txtSearch.Text.ToLower());
            int foundIndex = wiki.BinarySearch(searchData);
            if (foundIndex >= 0)
            {
                lvDisplay.SelectedItems.Clear();
                lvDisplay.Items[foundIndex].Selected = true;
                lvDisplay.Focus();
                txtName.Text = wiki[foundIndex].getName();
                cboCategory.Text = wiki[foundIndex].getCategory();
                setStructure(foundIndex);
                txtDefinition.Text = wiki[foundIndex].getDefinition();
                stsMsglbl.Text = txtName.Text + " fond in row " + (foundIndex + 1);
            }
            else
            {
                stsMsglbl.Text = "Not found";
                txtSearch.Clear();
                txtSearch.Focus();
            }
        }
        #endregion

        #region FILE IO
        // 6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file
        // or rename a saved file.All Wiki data is stored/retrieved using a binary reader/writer file format.
        private void btnOpen_Click(object sender, EventArgs e)
        {
            stsMsglbl.Text = "";
            string fileName = "WikiInformation.bin";
            OpenFileDialog OpenBinFile = new OpenFileDialog();
            OpenBinFile.InitialDirectory = Application.StartupPath;
            OpenBinFile.Filter = "BIN |*.bin";
            OpenBinFile.Title = "Open a binary file..";
            DialogResult sr = OpenBinFile.ShowDialog();
            if (sr == DialogResult.OK)
            {
                fileName = OpenBinFile.FileName;
            }
            try
            {
                wiki.Clear();
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    using (var br = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        while (stream.Position < stream.Length)
                        {
                            Information data = new Information();
                            data.setName(br.ReadString());
                            data.setCategory(br.ReadString()); // -- To be fixed.
                            data.setStructure(br.ReadString());
                            data.setDefinition(br.ReadString());
                            wiki.Add(data);
                        }
                    }
                }
                stsMsglbl.Text = "new file";
                DisplayData();
            }
            catch (IOException)
            {
                MessageBox.Show("Could not open Wiki information", "Critical Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            stsMsglbl.Text = "";
            string fileName = "WikiInformation.bin";
            SaveFileDialog SaveBinFile = new SaveFileDialog();
            SaveBinFile.InitialDirectory = Application.StartupPath;
            SaveBinFile.Filter = "BIN |*.bin";
            SaveBinFile.Title = "Save your bin file";
            DialogResult sr = SaveBinFile.ShowDialog();
            if (sr == DialogResult.Cancel)
            {
                SaveBinFile.FileName = fileName;
            }
            if (sr == DialogResult.OK)
            {
                fileName = SaveBinFile.FileName;
            }
            try
            {
                using (var stream = File.Open(fileName, FileMode.Create))
                {
                    using (var bw = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        foreach (var data in wiki)
                        {
                            bw.Write(data.getName());
                            bw.Write(data.getCategory());//  -- To be fixed.
                            bw.Write(data.getStructure());
                            bw.Write(data.getDefinition());
                        }
                    }
                }
                stsMsglbl.Text = "Filfe saved";
                ClearResetInput();
            }
            catch (IOException)
            {
                MessageBox.Show("Could not save Wiki information", "Critical Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 6.15 The Wiki application will save data when the form closes.
        #endregion

        #region EVENTS
        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names
        // and the associated information will be displayed in the related text boxes combo box and radio button.
        private void lvDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            stsMsglbl.Text = "";
            Information data = new Information();
            int selectedIndex = lvDisplay.SelectedIndices[0];
            // Setters
            data.setName(lvDisplay.SelectedItems[0].SubItems[0].Text);
            data.setCategory(lvDisplay.SelectedItems[0].SubItems[1].Text);
            data.setDefinition(lvDisplay.SelectedItems[0].SubItems[3].Text);

            // Display
            txtName.Text = data.getName();
            cboCategory.Text = data.getCategory();
            setStructure(selectedIndex);
            txtDefinition.Text = data.getDefinition();
        }

        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button. 
        private void txtName_DoubleClick(object sender, EventArgs e)
        {
            ClearResetInput();
            stsMsglbl.Text = "";
        }

        #endregion

        #region CUSTOM METHODS
        // 6.4 Create a custom method to populate the ComboBox when the Form Load method is called.
        // The six categories must be read from a simple text file. 
        private void PopulateComboBox()
        {
            string filePath = "categories.txt";
            try
            {
                string[] categories = File.ReadAllLines(filePath); // read all lines from file
                cboCategory.Items.AddRange(categories); // add categories to ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading categories from file: {ex.Message}");
            }
        }
        private void FormWiki_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }

        // 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name
        // and returns a Boolean after checking for duplicates.Use the built in List<T> method “Exists” to answer this requirement.
        private bool ValidName(string newName)
        {
            if (wiki.Exists(x => x.getName() == newName.ToLower())) // No need to use "foreach (Information data in wiki)" go through each element.
                return false;
            else
                return true;
        }

        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox.  ---- TO BE CONFIRMED, should the two method go to the information class?
        // The first method must return a string value from the selected radio button(Linear or Non-Linear).
        // The second method must send an integer index which will highlight an appropriate radio button.
        private string getStructure()
        {
            string rboValue = "";
            foreach (RadioButton rbo in gbStructure.Controls.OfType<RadioButton>())
            {
                if (rbo.Checked)
                {
                    rboValue = rbo.Text;
                    break;
                }
                else
                {
                    rboValue = "Other";
                }
            }
            return rboValue;
        }
        private void setStructure(int rdoIndex)
        {
            foreach (RadioButton rbo in gbStructure.Controls.OfType<RadioButton>())
            {
                if (rbo.Text == wiki[rdoIndex].getStructure())
                {
                    rbo.Checked = true;
                }
                else
                {
                    rbo.Checked = false;
                }
            }
        }

        // 6.9 Create a single custom method that will sort and then
        // display the Name and Category from the wiki information in the list.
        private void DisplayData()
        {
            lvDisplay.Items.Clear();
            wiki.Sort(); // Becuse of using Icomparabel, so it can be sorted by Name column.
            foreach (var data in wiki)
            {
                ListViewItem item = new ListViewItem(data.getName());
                item.SubItems.Add(data.getCategory());
                item.SubItems.Add(data.getStructure());
                item.SubItems.Add(data.getDefinition());
                lvDisplay.Items.Add(item);
            }
        }
        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button 
        private void ClearResetInput()
        {
            txtSearch.Clear();
            txtName.Clear();
            cboCategory.SelectedIndex = 0; // set the value to the first item in the list
            // set all radio buttons to un-checked
            foreach (RadioButton rbo in gbStructure.Controls.OfType<RadioButton>())
            {
                rbo.Checked = false;
            }
            txtDefinition.Clear();
            txtName.Focus();
        }
        #endregion
    }
}
