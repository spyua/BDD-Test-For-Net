namespace ShoppingCartCaseStudy
{
    partial class Form_ShoppingCart
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_ShoppingCart = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShoppingCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ShoppingCart
            // 
            this.dgv_ShoppingCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShoppingCart.Location = new System.Drawing.Point(34, 46);
            this.dgv_ShoppingCart.Name = "dgv_ShoppingCart";
            this.dgv_ShoppingCart.Size = new System.Drawing.Size(432, 360);
            this.dgv_ShoppingCart.TabIndex = 0;
            // 
            // Form_ShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_ShoppingCart);
            this.Name = "Form_ShoppingCart";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShoppingCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ShoppingCart;
    }
}

