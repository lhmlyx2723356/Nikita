using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace Nikita.Report.WinForm
{
    public partial class MatrixDialog : Form
    {
        public delegate void ApplyChanges(List<string> rowFields, List<string> columnFields, List<string> summarizedFields);

        private List<string> m_allFields;
        private List<string> m_rowFields;
        private List<string> m_columnFields;
        private List<string> m_summarizedFields;
        public ApplyChanges m_applyCallback;

        public MatrixDialog()
        {
            InitializeComponent();
        }

        public ApplyChanges ApplyCallback
        {
            set
            {
                m_applyCallback = value;
            }
        }

        public List<string> AllFields
        {
            get { return m_allFields; }
            set { m_allFields = value; }
        }

        public List<string> RowFields
        {
            get { return m_rowFields; }
            set { m_rowFields = value; }
        }

        public List<string> ColumnFields
        {
            get { return m_columnFields; }
            set { m_columnFields = value; }
        }

        public List<string> SummarizedFields
        {
            get { return m_summarizedFields; }
            set { m_summarizedFields = value; }
        }

        private void MatrixDialog_Load(object sender, EventArgs e)
        {
            if (m_allFields != null)
            {
                List<string> availableFields = new List<string>();
                availableFields.AddRange(m_allFields);

                if (m_rowFields != null)
                {
                    foreach (string s in m_rowFields)
                    {
                        rowFieldsListBox.Items.Add(s);
                        availableFields.Remove(s);
                    }
                }
                if (m_columnFields != null)
                {
                    foreach (string s in m_columnFields)
                    {
                        columnFieldsListBox.Items.Add(s);
                        availableFields.Remove(s);
                    }
                }
                if (m_summarizedFields != null)
                {
                    foreach (string s in m_summarizedFields)
                    {
                        summarizedFieldsListBox.Items.Add(s);
                        availableFields.Remove(s);
                    }
                }
                foreach (string s in availableFields)
                    availableFieldsListBox.Items.Add(s);
            }
            if (m_applyCallback == null)
                applyButton.Visible = false;
            EnableDisableControls();
        }

        private List<string> GetListBoxItems(ListBox listBox)
        {
            ListBox.ObjectCollection objects = listBox.Items;
            List<string> items = new List<string>();
            foreach (object obj in objects)
                items.Add(obj.ToString());
            return items;
        }

        private void MoveAvailableField(object sender)
        {
            if (availableFieldsListBox.SelectedItem == null)
                return;

            if (sender == this.addColumnFieldButton)
                columnFieldsListBox.Items.Add(availableFieldsListBox.SelectedItem);
            else if (sender == this.addRowFieldButton)
                rowFieldsListBox.Items.Add(availableFieldsListBox.SelectedItem);
            else if (sender == this.addSummarizedFieldButton)
                summarizedFieldsListBox.Items.Add(availableFieldsListBox.SelectedItem);

            availableFieldsListBox.Items.Remove(availableFieldsListBox.SelectedItem);
            if (availableFieldsListBox.Items.Count > 0)
                availableFieldsListBox.SelectedIndex = 0;

            availableFieldsListBox.Focus();
        }

        private void RestoreAvailableField(object sender)
        {
            object field = null;

            if (sender == this.removeColumnFieldButton)
            {
                field = columnFieldsListBox.SelectedItem;
                columnFieldsListBox.Items.Remove(field);
            }
            else if (sender == this.removeRowFieldButton)
            {
                field = rowFieldsListBox.SelectedItem;
                rowFieldsListBox.Items.Remove(field);
            }
            else if (sender == this.removeSummarizedFieldButton)
            {
                field = summarizedFieldsListBox.SelectedItem;
                summarizedFieldsListBox.Items.Remove(field);
            }

            if (field == null)
                return;
            availableFieldsListBox.Items.Add(field);
        }

        private void addColumnFieldButton_Click(object sender, EventArgs e)
        {
            MoveAvailableField(sender);
            EnableDisableControls();
        }

        private void removeColumnFieldButton_Click(object sender, EventArgs e)
        {
            RestoreAvailableField(sender);
            EnableDisableControls();
        }

        private void addRowFieldButton_Click(object sender, EventArgs e)
        {
            MoveAvailableField(sender);
            EnableDisableControls();
        }

        private void removeRowFieldButton_Click(object sender, EventArgs e)
        {
            RestoreAvailableField(sender);
            EnableDisableControls();
        }

        private void addSummarizedFieldButton_Click(object sender, EventArgs e)
        {
            MoveAvailableField(sender);
            EnableDisableControls();
        }

        private void removeSummarizedFieldButton_Click(object sender, EventArgs e)
        {
            RestoreAvailableField(sender);
            EnableDisableControls();
        }

        private void availableFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableFieldsListBox.SelectedItem != null)
            {
                columnFieldsListBox.SelectedItem = null;
                rowFieldsListBox.SelectedItem = null;
                summarizedFieldsListBox.SelectedItem = null;
            }
            EnableDisableControls();
        }

        private void columnFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (columnFieldsListBox.SelectedItem != null)
            {
                availableFieldsListBox.SelectedItem = null;
                rowFieldsListBox.SelectedItem = null;
                summarizedFieldsListBox.SelectedItem = null;
            }
            EnableDisableControls();
        }

        private void rowFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rowFieldsListBox.SelectedItem != null)
            {
                availableFieldsListBox.SelectedItem = null;
                columnFieldsListBox.SelectedItem = null;
                summarizedFieldsListBox.SelectedItem = null;
            }
            EnableDisableControls();
        }

        private void summarizedFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (summarizedFieldsListBox.SelectedItem != null)
            {
                availableFieldsListBox.SelectedItem = null;
                rowFieldsListBox.SelectedItem = null;
                columnFieldsListBox.SelectedItem = null;
            }
            EnableDisableControls();
        }

        private void MoveItemUp(ListBox listBox, ListBox previousListBox)
        {
            int index = listBox.SelectedIndex;
            if (index == 0 && previousListBox == null)
                return;
            object item = listBox.SelectedItem;
            listBox.Items.Remove(item);

            ListBox newListBox;
            int newIndex;

            if (index == 0)
            {
                newListBox = previousListBox;
                newIndex = newListBox.Items.Count;
            }
            else
            {
                newListBox = listBox;
                newIndex = index - 1;
            }

            newListBox.Items.Insert(newIndex, item);
            newListBox.SelectedIndex = newIndex;
        }

        private void MoveItemDown(ListBox listBox, ListBox nextListBox)
        {
            int index = listBox.SelectedIndex;
            bool isLastItem = (index == listBox.Items.Count - 1);
            if (isLastItem && nextListBox == null)
                return;
            object item = listBox.SelectedItem;
            listBox.Items.Remove(item);

            ListBox newListBox;
            int newIndex;

            if (isLastItem)
            {
                newListBox = nextListBox;
                newIndex = 0;
            }
            else
            {
                newListBox = listBox;
                newIndex = index + 1;
            }

            newListBox.Items.Insert(newIndex, item);
            newListBox.SelectedIndex = newIndex;
        }

        private void upArrowButton_Click(object sender, EventArgs e)
        {
            if (columnFieldsListBox.SelectedIndex != -1)
                MoveItemUp(columnFieldsListBox, null);
            else if (rowFieldsListBox.SelectedIndex != -1)
                MoveItemUp(rowFieldsListBox, columnFieldsListBox);
            else if (summarizedFieldsListBox.SelectedIndex != -1)
                MoveItemUp(summarizedFieldsListBox, rowFieldsListBox);
            EnableDisableControls();
        }

        private void downArrowButton_Click(object sender, EventArgs e)
        {
            if (columnFieldsListBox.SelectedIndex != -1)
                MoveItemDown(columnFieldsListBox, rowFieldsListBox);
            else if (rowFieldsListBox.SelectedIndex != -1)
                MoveItemDown(rowFieldsListBox, summarizedFieldsListBox);
            else if (summarizedFieldsListBox.SelectedIndex != -1)
                MoveItemDown(summarizedFieldsListBox, null);
            EnableDisableControls();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (m_applyCallback != null)
            {
                m_applyCallback(GetListBoxItems(rowFieldsListBox), 
                     GetListBoxItems(columnFieldsListBox), GetListBoxItems(summarizedFieldsListBox));
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            m_allFields = GetListBoxItems(availableFieldsListBox);
            m_rowFields = GetListBoxItems(rowFieldsListBox);
            m_columnFields = GetListBoxItems(columnFieldsListBox);
            m_summarizedFields = GetListBoxItems(summarizedFieldsListBox);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EnableDisableControls()
        {
            okButton.Enabled = (rowFieldsListBox.Items.Count > 0) &&
                               (columnFieldsListBox.Items.Count > 0) &&
                               (summarizedFieldsListBox.Items.Count > 0);
            applyButton.Enabled = okButton.Enabled;
            upArrowButton.Enabled = (rowFieldsListBox.SelectedIndex != -1) ||
                                    (columnFieldsListBox.SelectedIndex != -1) ||
                                    (summarizedFieldsListBox.SelectedIndex != -1);
            downArrowButton.Enabled = upArrowButton.Enabled;
            addColumnFieldButton.Enabled = addRowFieldButton.Enabled =
                  addSummarizedFieldButton.Enabled = (availableFieldsListBox.SelectedIndex != -1);
            removeColumnFieldButton.Enabled = (columnFieldsListBox.SelectedIndex != -1);
            removeRowFieldButton.Enabled = (rowFieldsListBox.SelectedIndex != -1);
            removeSummarizedFieldButton.Enabled = (summarizedFieldsListBox.SelectedIndex != -1);
        }
    }
}