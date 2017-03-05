using System;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;

namespace jarvis
{
    public partial class Jarvis : Form
    {
        public static Bitmap quantity;
        SpeechRecognitionEngine recengine = new SpeechRecognitionEngine();
        System.Speech.Synthesis.SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        Random random = new Random();
        string firefoxpath = "";
        string skypepath = "";
        string originpath = "";
        public Boolean search = false;
       public static Bitmap bg = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        
        public Jarvis()
        {
            InitializeComponent();
        }

        private void Jarvis_Load(object sender, EventArgs e)
        {

            Choices commands = new Choices();
            string[] lista = { "go away", "open safe mail", "come back", "write commands", "search for", "open origin", "disable", "open youtube", "open notepad", "open command line", "show commands", "open skype", "open reddit", "speak selected text", "Hello", "Hi", "open firefox", "open facebook", "what time is it", "open hacker news", "exit", "open code", "take screenshot", "etsi" };
            foreach (string lista2 in lista)
            {
                richTextBox2.Text += lista2 + ", ";
            }
            //Bitmap bg = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            commands.Add(lista);
            
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(commands);
            Grammar grammar = new Grammar(gbuilder);

            recengine.LoadGrammarAsync(grammar);

            recengine.SetInputToDefaultAudioDevice();
            recengine.SpeechRecognized += Recengine_SpeechRecognized;
        }

        public void Recengine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            
            string Speech = e.Result.Text;


            //not working
            if (e.Result.Text.Contains("search for"));
            {
                Speech = String.Empty;
                richTextBox1.Text += "yes sir";
                search = true;

            }

            //not working
            if (search == true)
            {
                Process.Start("https://www.google.fi/#q=" + Speech);
                search = false;
            }


            switch (e.Result.Text)
            {


                              
                case "Hello":
                case "Hi":
                    int randomi = random.Next(1, 3);
                    if (randomi == 1)
                    {
                        synthesizer.SpeakAsync("hello my creator");
                        richTextBox1.Text += "\nhello my creator";
                        break;
                    }
                    else if (randomi == 2)
                    {
                        synthesizer.SpeakAsync("hello my creator, did you have a nice day");
                        richTextBox1.Text += "\nhello my creator,  did you have a nice day";
                        break;
                    }
                    else
                    {

                        synthesizer.SpeakAsync("hello my creator, how are you");
                        richTextBox1.Text += "\nhello my creator, how are you";
                        break;
                    }

                case "open youtube":
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    System.Diagnostics.Process.Start("https://www.youtube.com");
                    break;

                case "open firefox":
                    try
                    {
                        TextReader file = new StreamReader(@"F:\jarvispath\firefoxpath.txt");
                        firefoxpath = file.ReadLine();
                        synthesizer.SpeakAsync("yes sir");
                        richTextBox1.Text += "\nyes sir";
                        //MessageBox.Show(settings.firefox);
                        System.Diagnostics.Process.Start(firefoxpath);
                        break;
                    }
                    catch (InvalidOperationException inv)
                    {
                        synthesizer.SpeakAsync("error");
                        richTextBox1.Text += "\nerror";
                        break;
                    }
                case "open skype":
                    try
                    {

                        TextReader skype = new StreamReader(@"F:\jarvispath\skypepath.txt");
                        skypepath = skype.ReadLine();
                        synthesizer.SpeakAsync("yes sir");
                        richTextBox1.Text += "\nyes sir";
                        System.Diagnostics.Process.Start(skypepath);
                        break;
                    }
                    catch (InvalidOperationException skyperror)
                    {
                        synthesizer.SpeakAsync("error");
                        richTextBox1.Text += "\nerror";
                        break;
                    }
                case "open origin":
                    try
                    {
                        TextReader origin = new StreamReader(@"F:\jarvispath\originpath.txt");
                        originpath = origin.ReadLine();
                        synthesizer.SpeakAsync("yes sir");
                        richTextBox1.Text += "\nyes sir";
                        System.Diagnostics.Process.Start(originpath);
                        break;
                    }
                    catch (InvalidOperationException originerror)
                    {
                        synthesizer.SpeakAsync("error");
                        richTextBox1.Text += "\nerror";
                        break;
                    }

                case "open facebook":
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    System.Diagnostics.Process.Start("https://www.facebook.com/");
                    break;
                case "what time is it":
                    DateTime now = System.DateTime.Now;
                    string time = now.GetDateTimeFormats('t')[0];
                    synthesizer.SpeakAsync(time);
                    richTextBox1.Text += "\n";
                    richTextBox1.Text += time;
                    break;
                case "open hacker news":
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    System.Diagnostics.Process.Start("http://thehackernews.com/");
                    break;
                case "exit":
                    this.Close();
                    break;
                case "speak selected text":
                    synthesizer.SpeakAsync(richTextBox1.SelectedText);
                    break;
                case "open code":
                    synthesizer.SpeakAsync("you are going to make me better?");
                    richTextBox1.Text += "\nyou are going to make me better?";
                    System.Diagnostics.Process.Start(@"F:\jarvis\jarvis.sln");
                    break;
                case "open reddit":
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    System.Diagnostics.Process.Start("https://www.reddit.com/r/security");
                    break;


                case "show commands":
                    System.Diagnostics.Process.Start(@"F:\choices.txt");
                    break;
                case "open command line":
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    System.Diagnostics.Process.Start("cmd.exe");
                    break;
                case "open notepad":
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    System.Diagnostics.Process.Start("notepad");
                    break;
                case "go away":
                    if (this.WindowState != FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                    break;
                case "disable":
                    recengine.RecognizeAsyncStop();
                    button1.Enabled = true;
                    button2.Enabled = false;
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    break;
                case "come back":
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    break;
                case "open safe mail":
                    System.Diagnostics.Process.Start("https://orange.safe-mail.net/cgi-bin/Safe-mail.net/gate/N1O-568a7110-3f67b389");
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    break;
                case "take screenshot":


                    Form.ActiveForm.Opacity = 0;
                    Graphics gb = Graphics.FromImage(bg as Image);
                    gb.CopyFromScreen(0, 0, 0, 0, bg.Size);
                    Form.ActiveForm.Opacity = 100;
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    saveFileDialog2.Filter = "jpeg image|*.jpg";
                    saveFileDialog2.ShowDialog();
                    bg.Save(saveFileDialog2.FileName);
                    synthesizer.SpeakAsync("yes sir");
                    richTextBox1.Text += "\nyes sir";
                    Form3 fmr3 = new Form3();
                    fmr3.Show();




                    break;
                /*case "etsi":
                    string query = Speech.Replace("etsi", e.Result.Text); 

                    query = System.Web.HttpUtility.UrlEncode(query);
                    string url = "https://www.google.com/search?q=" + e.Result.Text;
                    System.Diagnostics.Process.Start(url);
                  */ //break;


                default:
                   
             

                    break;
            }
        }





      
        
        private void button1_Click(object sender, EventArgs e)
        {
            recengine.RecognizeAsync(RecognizeMode.Multiple);
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recengine.RecognizeAsyncStop();
            button2.Enabled = false;
            button1.Enabled = true;
            
        }

        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"F:\choices.txt");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)

        {
            settings Settings = new settings();
            Settings.ShowDialog();
        }



        public void senddata()
        {
            


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(saveFileDialog2.FileName);
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
