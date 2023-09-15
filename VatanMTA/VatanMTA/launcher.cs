using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatanMTA
{
    public partial class launcher : Form
    {
        public launcher()
        {
            InitializeComponent();
        }

        string vatanIP = "mtasa://185.160.30.14:22003";

        private DiscordRPC.EventHandlers handlers;
        private DiscordRPC.RichPresence presence;
        void RPC()
        {
            this.handlers = default(DiscordRPC.EventHandlers);
            DiscordRPC.Initialize("1081614012963368981", ref this.handlers, true, null);
            this.presence.details = "[TR] Vatan Roleplay | discord.gg/vatanmta";
            this.presence.state = "#NewSeason";
            this.presence.largeImageKey = "logo";
            this.presence.largeImageText = "discord.gg/vatanmta";
            this.presence.smallImageKey = "chirless";
            this.presence.smallImageText = "Developed by Chirless";
            this.presence.startTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            DiscordRPC.UpdatePresence(ref this.presence);
        }

        Point pnlM;
        private void label5_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) pnlM = e.Location; }

        private void label5_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { this.Left += e.X - pnlM.X; this.Top += e.Y - pnlM.Y; } }

        private void label3_MouseHover(object sender, EventArgs e) => label3.BackColor = Color.IndianRed;

        private void label4_MouseHover(object sender, EventArgs e) => label4.BackColor = Color.LightGray;

        private void label3_MouseLeave(object sender, EventArgs e) => label3.BackColor = Color.White;

        private void label4_MouseLeave(object sender, EventArgs e) => label4.BackColor = Color.White;

        private void label3_Click(object sender, EventArgs e) => Application.Exit();

        private void label4_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void launcher_Load(object sender, EventArgs e) => RPC();

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Başarıyla giriş yapıyorsunuz.", "VatanMTA - discord.gg/vatanmta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(vatanIP);
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
