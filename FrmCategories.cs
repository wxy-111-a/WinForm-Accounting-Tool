using Bookkeeping.BLL;
using Bookkeeping.Model;
using System;
using System.Windows.Forms;

namespace Bookkeeping.UI
{
    public partial class FrmCategories : Form
    {
        private readonly CategoryBLL _categoryBLL = new CategoryBLL();

        public FrmCategories()
        {
            InitializeComponent();
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            LoadCategories();
            // 初始化下拉框
            cmbType.Items.Add("支出");
            cmbType.Items.Add("收入");

            SetNewMode();
        }

        private void LoadCategories()
        {
            dgvCategories.DataSource = _categoryBLL.GetAllCategories();
            // 美化列头
            dgvCategories.Columns["CategoryID"].HeaderText = "ID";
            dgvCategories.Columns["CategoryName"].HeaderText = "分类名称";
            dgvCategories.Columns["Type"].HeaderText = "类型";
        }

        private void SetNewMode()
        {
            lblCategoryId.Text = string.Empty;
            txtCategoryName.Clear();
            cmbType.SelectedIndex = 0; // 默认选中“支出”

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            dgvCategories.ClearSelection();
            txtCategoryName.Focus();
        }

        private void SetEditMode()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                lblCategoryId.Text = row.Cells["CategoryID"].Value.ToString();
                txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
                cmbType.SelectedItem = row.Cells["Type"].Value.ToString();

                SetEditMode();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetNewMode();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("分类名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newCategory = new Category
            {
                CategoryName = txtCategoryName.Text.Trim(),
                Type = cmbType.SelectedItem.ToString()
            };

            if (_categoryBLL.AddCategory(newCategory))
            {
                MessageBox.Show("添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                SetNewMode();
            }
            else
            {
                MessageBox.Show("添加失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text) || string.IsNullOrEmpty(lblCategoryId.Text))
            {
                MessageBox.Show("请先选择一个要更新的分类！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updatedCategory = new Category
            {
                CategoryID = int.Parse(lblCategoryId.Text),
                CategoryName = txtCategoryName.Text.Trim(),
                Type = cmbType.SelectedItem.ToString()
            };

            if (_categoryBLL.UpdateCategory(updatedCategory))
            {
                MessageBox.Show("更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                SetNewMode();
            }
            else
            {
                MessageBox.Show("更新失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCategoryId.Text))
            {
                MessageBox.Show("请先选择一个要删除的分类！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确定要删除这个分类吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int categoryId = int.Parse(lblCategoryId.Text);
                if (_categoryBLL.DeleteCategory(categoryId))
                {
                    MessageBox.Show("删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                    SetNewMode();
                }
                else
                {
                    MessageBox.Show("删除失败！请检查该分类下是否还有交易记录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}