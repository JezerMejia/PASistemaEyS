using System;
using Gtk;
using SistemaEyS.UserForms;
using SistemaEyS.AdminForms;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void BtnEnterUserLoginOnClicked(object sender, EventArgs e)
    {
        UserLogin userLoginWindow = new UserLogin(this);
        this.Hide();
        userLoginWindow.Show();
    }

    protected void BtnEnterAdminLoginOnClicked(object sender, EventArgs e)
    {
        AdminLogin adminLoginWindow = new AdminLogin(this);
        this.Hide();
        adminLoginWindow.Show();
    }
}
