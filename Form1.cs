using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
            // error trapping in the Information class   - to be fixed  eg.empty input
            Information addData = new Information();
            bool isValid = ValidName(txtName.Text); // Calling ValidName method.
            if (isValid)
            {
                addData.setName(txtName.Text);
                // addData.setCategory(GetManufacturerRadioButton());
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
        // 6.7 Create a button method that will delete the currently selected record in the ListView.
        // Ensure the user has the option to backout of this action by using a dialog box.
        // Display an updated version of the sorted list at the end of this process. 
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView.
        // All the changes in the input controls will be written back to the list.
        // Display an updated version of the sorted list at the end of this process. 
        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region  BUILTIN BINARY SEARCH
        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        // If the record is found the associated details will populate the appropriate input controls
        // and highlight the name in the ListView. At the end of the search process the search input TextBox must be cleared.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            stsMsglbl.Text = "";
            //wiki.Sort();
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
                //cbo.Text = wiki[foundIndex].getCategory();
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

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        // 6.15 The Wiki application will save data when the form closes.
        #endregion

        #region EVENTS
        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names
        // and the associated information will be displayed in the related text boxes combo box and radio button.
        private void lvDisplay_MouseClick(object sender, MouseEventArgs e)
        {

        }
        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button. 
        private void txtName_DoubleClick(object sender, EventArgs e)
        {

        }

        #endregion

        #region CUSTOM METHODS
        // 6.4 Create a custom method to populate the ComboBox when the Form Load method is called.
        // The six categories must be read from a simple text file. 


        // 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name
        // and returns a Boolean after checking for duplicates.Use the built in List<T> method “Exists” to answer this requirement.
        private bool ValidName(string newName)
        {
            foreach(Information data in wiki)
            {
                if (wiki.Exists(x => x.getName() == newName.ToLower()))
                {
                    return false;
                }                
            }
            return true;
        }

        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        // The first method must return a string value from the selected radio button(Linear or Non-Linear).
        // The second method must send an integer index which will highlight an appropriate radio button.  -- TO BE CONFIRMED.
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
            wiki.Sort();
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
            txtName.Clear();
            // cboCategory.SelectedIndex = 0; // set the value to the first item in the list  -- to be fixed.
            // set all radio buttons to un-checked
            foreach (RadioButton rbo in gbStructure.Controls.OfType<RadioButton>())
            {
                rbo.Checked = false;
            }
            txtDefinition.Clear();
        }
        #endregion

    }
}
