using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bsnl.BOL;
using Bsnl.DAL;
using Bsnl.Validation;
using JmGrove.BOL;

namespace Bsnl
{
    public partial class FrmDesignation : Form
    {
        bool flag;
        public FrmDesignation()
        {
            InitializeComponent();
            dgDesig.Font = new Font(dgDesig.Font.FontFamily, 9);
            Display();
            CtrlState(false, 421);
            flag = false;

        }
        private void Display()
        {
            dgDesig.AutoGenerateColumns = false;
            dgDesig.DataSource = Desig.GetStates();

        }
        private void CtrlState(bool state, int height)
        {
            txtDesig.Visible = state;
            ddlDesignType.Visible = state;           
            btnAdd.Enabled = !state;
            btnSave.Enabled = state;
            btnDelete.Enabled = !state;
            btnCancel.Enabled = state;
            dgDesig.Enabled = !state;
            dgDesig.Height = height;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CtrlState(true, 388);
            flag = true;
            GetDesignationType();
            txtdesigId.Text = Desig.GetMaxStateId();
            txtDesig.Clear();            
            txtDesig.Focus();
        }

        private void dgDesig_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgDesig.SelectedRows.Count > 0)
            {
                GetDesignationType();
                CtrlState(true, 388);
                flag = false;
                txtdesigId.Text = dgDesig.SelectedRows[0].Cells[1].Value.ToString();              
                txtDesig.Text = dgDesig.SelectedRows[0].Cells[2].Value.ToString();
                int id = Convert.ToInt32(CommonFunction.GetDesignationTypeID(Convert.ToString(dgDesig.SelectedRows[0].Cells[3].Value)));
                ddlDesignType.SelectedValue = id;
                txtDesig.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (VD.IsNull(txtDesig)) return;

            try
            {
                Desig des = new Desig();
                des.DesigId = Convert.ToInt32(txtdesigId.Text);
                des.DesigNm = txtDesig.Text;
                des.DesigTypeID = Convert.ToInt32(ddlDesignType.SelectedValue.ToString());

                if (flag == true)
                    Desig.Save(des, "I");
                else if (flag == false)
                    Desig.Save(des, "U");

                CtrlState(false, 421);
                Display();
                GenerateSerialNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }


        private void GenerateSerialNo()
        {
            int i = 1;
            foreach (DataGridViewRow drow in dgDesig.Rows)
                drow.Cells["Sno"].Value = i++;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CtrlState(false, 421);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgDesig.SelectedRows.Count > 0)
            {
                DialogResult chk = MessageBox.Show("Do u want to delete Designation Type " + dgDesig.SelectedRows[0].Cells[2].Value, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (chk == DialogResult.Yes)
                {
                    try
                    {
                        string id = dgDesig.SelectedRows[0].Cells[1].Value.ToString();
                        Desig.Delete(id);
                        
                        Display();
                        GenerateSerialNo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void FrmDesignation_Load(object sender, EventArgs e)
        {
            GenerateSerialNo();
        }

        protected void GetDesignationType()
        {
            try
            {
                ddlDesignType.DataSource = CommonFunction.GetDesignationType();
                ddlDesignType.DisplayMember = "DesignationType";
                ddlDesignType.ValueMember = "id";
                
            }
            catch (Exception ex)
            {
                //Insert Error Message In Database
            }
        }
    }
}
