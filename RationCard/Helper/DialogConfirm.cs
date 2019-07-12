using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;

namespace RationCard.Helper
{
    public static class DialogConfirm
    {
        public static string ShowInputDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            textBox.PasswordChar = '*';
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public static string ShowInformationDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                Font = new Font(FontFamily.GenericSansSerif, 10 )
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Width=200, Height=100, Text = text };
            Button confirmation = new Button() { Text = "Ok",Height=40, Left = 100, Width = 90, Top = 100, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? "" : "";
        }

        public static void ShowInfohScreen(string text, bool isToClose = false)
        {
            try
            {
                Form frmObj = Application.OpenForms["FrmSplashScreen"];
                if (isToClose)
                {
                    frmObj.Close();
                }
                else
                {
                    if (frmObj != null)
                    {
                        frmObj.Show();
                        frmObj.Controls["txtLable"].Text = text;
                    }
                    else
                    {
                        frmObj = new Form()
                        {
                            Width = 300,
                            Height = 200,
                            FormBorderStyle = FormBorderStyle.None,
                            AllowTransparency = true,
                            TransparencyKey = Color.Turquoise,
                            BackColor = Color.Turquoise,
                            Opacity = .65,
                            StartPosition = FormStartPosition.CenterScreen,
                            Font = new Font(FontFamily.GenericSerif, 10),
                            Name = "FrmSplashScreen"
                        };
                        Label textLabel = new Label() { Name = "txtLable", Left = 50, Top = 20, Width = 200, Height = 100, Text = text };
                        frmObj.Controls.Add(textLabel);

                        frmObj.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
