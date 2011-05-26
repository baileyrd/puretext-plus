﻿/*
    PureText+ - http://code.google.com/p/puretext-plus/
    
    Copyright (C) 2003 Steve P. Miller, http://www.stevemiller.net/puretext/
    Copyright (C) 2011 Melloware, http://www.melloware.com
    
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
    
    The idea of the Original PureText Code is Copyright (C) 2003 Steve P. Miller
    
    NO code was taken from the original project this was rewritten from scratch
    from just the idea of Puretext.
*/
namespace PureTextPlus
{
	partial class FormAbout
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
			this.imgIcon = new System.Windows.Forms.PictureBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.lblMelloware = new System.Windows.Forms.LinkLabel();
			this.lblOriginalAuthor = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.lnkMiller = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// imgIcon
			// 
			this.imgIcon.Image = ((System.Drawing.Image)(resources.GetObject("imgIcon.Image")));
			this.imgIcon.InitialImage = null;
			this.imgIcon.Location = new System.Drawing.Point(12, 12);
			this.imgIcon.Name = "imgIcon";
			this.imgIcon.Size = new System.Drawing.Size(54, 58);
			this.imgIcon.TabIndex = 0;
			this.imgIcon.TabStop = false;
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(72, 12);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(310, 23);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "PureTextPlus";
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(73, 46);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(331, 51);
			this.lblDescription.TabIndex = 2;
			this.lblDescription.Text = "Description";
			// 
			// lblCopyright
			// 
			this.lblCopyright.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCopyright.Location = new System.Drawing.Point(12, 97);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(215, 23);
			this.lblCopyright.TabIndex = 3;
			this.lblCopyright.Text = "Coppyright 2011 Melloware";
			this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMelloware
			// 
			this.lblMelloware.Location = new System.Drawing.Point(230, 97);
			this.lblMelloware.Name = "lblMelloware";
			this.lblMelloware.Size = new System.Drawing.Size(184, 23);
			this.lblMelloware.TabIndex = 4;
			this.lblMelloware.TabStop = true;
			this.lblMelloware.Text = "http://melloware.com";
			this.lblMelloware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblOriginalAuthor
			// 
			this.lblOriginalAuthor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOriginalAuthor.Location = new System.Drawing.Point(12, 120);
			this.lblOriginalAuthor.Name = "lblOriginalAuthor";
			this.lblOriginalAuthor.Size = new System.Drawing.Size(215, 23);
			this.lblOriginalAuthor.TabIndex = 5;
			this.lblOriginalAuthor.Text = "Based on PureText by Steve P. Miller";
			this.lblOriginalAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(165, 159);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// lnkMiller
			// 
			this.lnkMiller.Location = new System.Drawing.Point(230, 120);
			this.lnkMiller.Name = "lnkMiller";
			this.lnkMiller.Size = new System.Drawing.Size(184, 23);
			this.lnkMiller.TabIndex = 7;
			this.lnkMiller.TabStop = true;
			this.lnkMiller.Text = "http://www.stevemiller.net/puretext/";
			this.lnkMiller.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(416, 194);
			this.Controls.Add(this.lnkMiller);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.lblOriginalAuthor);
			this.Controls.Add(this.lblMelloware);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.imgIcon);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About PureTextPlus";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.LinkLabel lnkMiller;
		private System.Windows.Forms.LinkLabel lblMelloware;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblOriginalAuthor;
		private System.Windows.Forms.Label lblCopyright;
		private System.Windows.Forms.PictureBox imgIcon;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblTitle;
	}
}
