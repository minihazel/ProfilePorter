using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelfDestruct
{
    public partial class mainForm : Form
    {
        int default_item_height = 22; // item height
        int default_item_loc_x = 1; // keep 1
        int default_item_loc_y = 1; // item location startpoint
        int default_item_spacer = 22; // spacer between item to item

        public Color idleText = Color.LightGray;
        public Color idleColor = Color.FromArgb(255, 35, 35, 40);
        public Color hoverColor = Color.FromArgb(255, 30, 30, 35);
        public Color selectColor = Color.FromArgb(255, 25, 25, 30);
        public Font idleFont = new Font("Bahnschrift Light", 8, FontStyle.Regular);

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            displayProfileCounter.Text = "Clear list";
            pathBrowse.Text = "";
            profileTimer.Start();

            placeholderTitle.Select();
        }

        public void clearUI(Panel control /* or GroupBox // Panel */)
        {
            // server box
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                Label selected = control.Controls[i] as Label;
                if (selected != null)
                {
                    try
                    {
                        control.Controls.RemoveAt(i);
                        selected.Dispose();
                    }
                    catch (Exception err)
                    {
                        Debug.WriteLine($"ERROR: {err.ToString()}");
                        MessageBox.Show($"Oops! It seems like we received an error. If you're uncertain what it\'s about, please message the developer with a screenshot:\n\n{err.ToString()}", this.Text, MessageBoxButtons.OK);
                    }
                }
            }
        }

        public void clearInterface()
        {
            bBrowse.Visible = false;
            bBrowse.Text = "Select SPT folder to install to";

            pathBrowse.Visible = false;
            pathBrowse.Text = "Placeholder";

            placeholderLbl.Visible = false;
            bBrowse2.Visible = false;

            clearUI(oldProfilePanel);
        }

        public void listSystem(string[] arr)
        {
            clearUI(oldProfilePanel);
            for (int i = 0; i < arr.Length; i++)
            {
                Label lbl = new Label();

                JObject parsedProfile = JObject.Parse(File.ReadAllText(arr[i]));
                JToken _Nickname = parsedProfile.SelectToken("characters.pmc.Info.Nickname");
                JToken version = parsedProfile.SelectToken("aki.version");

                lbl.Text = $"{arr[i]} - {_Nickname} [{version}]";

                lbl.AutoSize = false;
                lbl.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Size = new Size(oldProfilePlaceholder.Size.Width - 2, default_item_height);
                lbl.Location = new Point(default_item_loc_x, default_item_loc_y + (i * default_item_spacer));
                lbl.Font = idleFont;
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = idleText;
                lbl.Margin = new Padding(1, 1, 1, 1);
                lbl.Cursor = Cursors.Hand;
                lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
                lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
                lbl.MouseDown += new MouseEventHandler(lbl_MouseDown);
                lbl.MouseUp += new MouseEventHandler(lbl_MouseUp);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Visible = true;
                oldProfilePanel.Controls.Add(lbl);
            }

            bBrowse.Visible = true;
            pathBrowse.Visible = true;
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
                if (label.BackColor != selectColor)
                {
                    label.BackColor = hoverColor;
                }
            }
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
                if (label.BackColor != selectColor)
                {
                    label.BackColor = idleColor;
                }
            }
        }

        private void lbl_MouseDown(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lbl = (System.Windows.Forms.Label)sender;

            if (lbl.Text != "")
            {
                if (lbl.BackColor == selectColor)
                {
                    lbl.BackColor = hoverColor;
                }
                else
                {
                    lbl.BackColor = selectColor;
                }
            }
        }

        private void lbl_MouseUp(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "") { }
        }

        private void oldProfilePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void oldProfilePanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null)
            {
                listSystem(files);
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            profileTimer.Stop();
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            List<string> moddedItems = new List<string>();
            bool success = false;

            if (bBrowse.Text.ToLower() == "select spt folder to install to")
            {
                OpenFileDialog folderBrowser = new OpenFileDialog();

                folderBrowser.ValidateNames = false;
                folderBrowser.CheckFileExists = false;
                folderBrowser.CheckPathExists = true;

                folderBrowser.FileName = "Select SPT folder.";
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.GetDirectoryName(folderBrowser.FileName.Replace("Select SPT folder to transfer your profile(s) to.", ""));

                    bool serverExists = File.Exists(Path.Combine(folderPath, "Aki.Server.exe"));
                    bool launcherExists = File.Exists(Path.Combine(folderPath, "Aki.Launcher.exe"));
                    bool fileExists = File.Exists(Path.Combine(folderPath, "EscapeFromTarkov.exe"));

                    if (serverExists && launcherExists && fileExists)
                    {
                        pathBrowse.Text = folderPath;

                        bBrowse2.Visible = true;
                        placeholderLbl.Visible = true;

                        bBrowse.Text = $"Transfer to \"{Path.GetFileName(folderPath)}\"";
                        placeholderTitle.Select();
                    }
                    else
                    {
                        MessageBox.Show("Invalid path. Please select an SPT folder that contains Aki.Server.exe.", this.Text, MessageBoxButtons.OK);
                    }
                }
            }
            else if (bBrowse.Text.ToLower().Contains("transfer to"))
            {
                string fullPath = Path.Combine(pathBrowse.Text, "user\\profiles");

                foreach (Control component in oldProfilePanel.Controls)
                {
                    if (component is Label)
                    {
                        int index = component.Text.Trim().IndexOf("-");
                        if (index != -1)
                        {
                            string newText = component.Text.Trim().Substring(0, index);

                            bool pathExists = File.Exists(newText);
                            if (pathExists)
                            {
                                // CHECK: if profile contains modded items
                                string _databaseItems = File.ReadAllText(Path.Combine(pathBrowse.Text, "Aki_Data\\Server\\database\\templates\\items.json"));
                                JObject _itemsDB = JObject.Parse(_databaseItems);
                                JObject _profile = JObject.Parse(File.ReadAllText(newText));
                                JToken _nick = _profile.SelectToken("characters.pmc.Info.Nickname");
                                JArray _inventoryItems = (JArray)_profile["characters"]["pmc"]["Inventory"]["items"];

                                for (int i = 0; i < _inventoryItems.Count; i++)
                                {
                                    JToken token = _inventoryItems[i];
                                    string tpl = token["_tpl"].ToString();
                                    string check = token["_id"].ToString();

                                    if (tpl != null && check != null)
                                    {
                                        if (_itemsDB[tpl] == null)
                                        {
                                            JObject obj = (JObject)token;
                                            moddedItems.Add($"{_nick} -> {tpl}");
                                            obj.Remove(token["parentId"].ToString());
                                        }
                                    }
                                }

                                if (moddedItems.Count == 1)
                                {
                                    string msg = $"One modded item was discovered:\n\n{string.Join(Environment.NewLine, moddedItems)}\n\nPlease delete it from your stash/inventory, then try again!";
                                    MessageBox.Show(msg, this.Text, MessageBoxButtons.OK);
                                    clearInterface();
                                    return;
                                }
                                else if (moddedItems.Count > 1)
                                {
                                    string msg = $"Several modded items were discovered:\n\n{string.Join(Environment.NewLine, moddedItems)}\n\nPlease delete them from your stash/inventory, then try again!";
                                    MessageBox.Show(msg, this.Text, MessageBoxButtons.OK);
                                    clearInterface();
                                    return;
                                }
                                else if (moddedItems.Count == 0)
                                {
                                    try
                                    {
                                        // start with setting up new profile
                                        string newPath = Path.Combine(fullPath, Path.GetFileName(newText.Trim()));
                                        if (File.Exists(newPath))
                                        {
                                            if (MessageBox.Show($"Profile {Path.GetFileName(newText)} exists in the new version. Would you like to delete it before proceeding?\n\nSelecting No will cancel the process.", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                            {
                                                try
                                                {
                                                    File.Delete(newPath);
                                                    File.Copy(newText, newPath, true);

                                                    // FIXING HIDEOUT PROBLEM
                                                    string newProfile = File.ReadAllText(newPath);
                                                    JObject newProfileJSON = JObject.Parse(newProfile);
                                                    JToken _Nickname = newProfileJSON.SelectToken("characters.pmc.Info.Nickname");
                                                    JToken gameVersion = newProfileJSON.SelectToken("characters.pmc.Info.GameVersion");
                                                    JToken isSide = newProfileJSON.SelectToken("characters.pmc.Info.Side");

                                                    string formattedGameVersion = gameVersion.ToString().ToLower();
                                                    string formattedSide = isSide.ToString().ToLower();
                                                    formattedGameVersion = formattedGameVersion.Replace("_", " ");
                                                    TextInfo formatGameVersion = new CultureInfo("en-US", false).TextInfo;
                                                    string formattedGameV = formatGameVersion.ToTitleCase(formattedGameVersion);

                                                    string templatesFile = File.ReadAllText(Path.Combine(pathBrowse.Text, "Aki_Data\\Server\\database\\templates\\profiles.json"));
                                                    JObject templatesJson = JObject.Parse(templatesFile);
                                                    JToken character = templatesJson[formattedGameV][formattedSide]["character"];
                                                    JToken fetchHideout = character.SelectToken("Hideout");

                                                    newProfileJSON.SelectToken("characters.pmc.Hideout").Replace(fetchHideout);
                                                    JToken pmc = newProfileJSON.SelectToken("characters.pmc.Inventory");

                                                    File.WriteAllText(newPath, JsonConvert.SerializeObject(newProfileJSON, Formatting.Indented));
                                                    success = true;
                                                }
                                                catch (Exception err)
                                                {
                                                    Debug.WriteLine($"ERROR: {err}");
                                                    MessageBox.Show($"Oops! It seems like we received an error. If you're uncertain what it\'s about, please message the developer with a screenshot:\n\n{err.ToString()}", this.Text, MessageBoxButtons.OK);
                                                }
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            File.Copy(newText, newPath, true);

                                            // FIXING HIDEOUT PROBLEM
                                            string newProfile = File.ReadAllText(newPath);
                                            JObject newProfileJSON = JObject.Parse(newProfile);
                                            JToken _Nickname = newProfileJSON.SelectToken("characters.pmc.Info.Nickname");
                                            JToken gameVersion = newProfileJSON.SelectToken("characters.pmc.Info.GameVersion");
                                            JToken isSide = newProfileJSON.SelectToken("characters.pmc.Info.Side");

                                            string formattedGameVersion = gameVersion.ToString().ToLower();
                                            string formattedSide = isSide.ToString().ToLower();
                                            formattedGameVersion = formattedGameVersion.Replace("_", " ");
                                            TextInfo formatGameVersion = new CultureInfo("en-US", false).TextInfo;
                                            string formattedGameV = formatGameVersion.ToTitleCase(formattedGameVersion);

                                            string templatesFile = File.ReadAllText(Path.Combine(pathBrowse.Text, "Aki_Data\\Server\\database\\templates\\profiles.json"));
                                            JObject templatesJson = JObject.Parse(templatesFile);
                                            JToken character = templatesJson[formattedGameV][formattedSide]["character"];
                                            JToken fetchHideout = character.SelectToken("Hideout");

                                            newProfileJSON.SelectToken("characters.pmc.Hideout").Replace(fetchHideout);
                                            JToken pmc = newProfileJSON.SelectToken("characters.pmc.Inventory");

                                            File.WriteAllText(newPath, JsonConvert.SerializeObject(newProfileJSON, Formatting.Indented));
                                            success = true;
                                        }
                                    }
                                    catch (Exception err)
                                    {
                                        Debug.WriteLine($"ERROR: {err}");
                                        MessageBox.Show($"Oops! It seems like we received an error. If you're uncertain what it\'s about, please message the developer with a screenshot:\n\n{err.ToString()}", this.Text, MessageBoxButtons.OK);
                                    }
                                }
                            }
                        }
                    }
                }

                if (success)
                {
                    string msg = $"Profile porting successful! Good luck!";
                    MessageBox.Show(msg, this.Text, MessageBoxButtons.OK);

                    clearInterface();
                }
                else
                {
                    string msg = $"Profile porting could not proceed, something went wrong. Please contact the developer if this issue persists.";
                    MessageBox.Show(msg, this.Text, MessageBoxButtons.OK);
                }
                placeholderTitle.Select();
            }
        }

        private void bBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();

            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;

            folderBrowser.FileName = "Select SPT folder.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName.Replace("Select SPT folder to transfer your profile(s) to.", ""));

                bool serverExists = File.Exists(Path.Combine(folderPath, "Aki.Server.exe"));
                bool launcherExists = File.Exists(Path.Combine(folderPath, "Aki.Launcher.exe"));
                bool fileExists = File.Exists(Path.Combine(folderPath, "EscapeFromTarkov.exe"));

                if (serverExists && launcherExists && fileExists)
                {
                    pathBrowse.Text = folderPath;
                }
                else
                {
                    MessageBox.Show("Invalid path. Please select an SPT folder that contains Aki.Server.exe.", this.Text, MessageBoxButtons.OK);
                }
            }
        }

        private void bBrowse2_MouseEnter(object sender, EventArgs e)
        {
            bBrowse2.ForeColor = Color.DodgerBlue;
        }

        private void bBrowse2_MouseLeave(object sender, EventArgs e)
        {
            bBrowse2.ForeColor = Color.LightGray;
        }

        private void displayProfileCounter_Click(object sender, EventArgs e)
        {
            clearUI(oldProfilePanel);
            clearInterface();

        }

        private void displayProfileCounter_MouseEnter(object sender, EventArgs e)
        {
            displayProfileCounter.ForeColor = Color.DodgerBlue;
        }

        private void displayProfileCounter_MouseLeave(object sender, EventArgs e)
        {
            displayProfileCounter.ForeColor = Color.LightGray;
        }
    }
}



// CHECKING INVENTORY FOR ITEMS THAT DON'T EXIST
// EXPERIMENTAL: unusable right now
/*
string databaseItems = File.ReadAllText(Path.Combine(pathBrowse.Text, "Aki_Data\\Server\\database\\templates\\items.json"));
JObject itemsDB = JObject.Parse(databaseItems);
JObject _inventory = JObject.Parse(pmc.ToString());
JArray inventoryItems = (JArray)_inventory["items"];

JObject encyclopedia = (JObject)newProfileJSON.SelectToken("characters.pmc.Encyclopedia");

for (int i = 0; i < inventoryItems.Count; i++)
{
    JToken token = inventoryItems[i];
    string tpl = token["_tpl"].ToString();
    string check = token["_id"].ToString();

    if (tpl != null && check != null)
    {
        if (itemsDB[tpl] == null)
        {
            inventoryItems.Remove(token);

            if (encyclopedia[tpl] != null)
            {
                encyclopedia.Remove(tpl);
            }
        }
    }
}

string updatedInventory = _inventory.ToString();

JObject updatedInventoryObject = JObject.Parse(updatedInventory);
newProfileJSON["characters"]["pmc"]["Inventory"]["items"] = updatedInventoryObject;
*/