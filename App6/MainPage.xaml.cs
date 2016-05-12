using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App6
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer myTimer = new DispatcherTimer();
        double t = 4.8;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            init();
            load();
            myTimer.Interval = new TimeSpan((int)(t*10000000));
            myTimer.Tick += new EventHandler<Object>(myTimer_tick);
            myTimer.Start();
        }
        String[] BigData = {"ACTION", "ALUMNI","AUGUST","ASPECT","ASLEEP","ARREST","ARRIVE","ASCENT","ARTIST","MINORS","MOTION","MOTIVE","MOTHER","MYSELF","MUSCLE","MURDER","MASTER","MUTANT","PARROT","MODIFY","MIRROR","MISTER","MISERY","MOSTLY","BUBBLE","BUTTER","BEAKER","BANNER","BANGLE","BECOME","BINARY","BITTER","BITING","BRIGHT","BRIDGE","BUNDLE","FABRIC","FACTOR","FACIAL","FARMER","FUTURE","FISHER","FISCAL","FIRMLY","FIRING","FUTILE","FUMING","FULFIL","FORGET","FONDER","FLIGHT","FINISH","PACKET","PADDLE","PACIFY","PICNIC","PIRACY","PUZZLE","PISTOL","PLURAL","PLAYER","PARDON","PATROL","PHOTON","PLEDGE","KETTLE","KIDNAP","KILLER","KIDNEY","KELVIN","NAPKIN","NARROW","NATIVE","NATION","NATURE","NEPHEW","NESTED","NOTION","NEPHEW","NESTLE","NOODLE","NOZZLE","NOTARY","CALORY","CANDLE","CANCEL","CANVAS","CAREER","CARBON","GAMBIT","GAMBLE","GENTLY","GLIDER","GLITCH","GREEDY","GARAGE","GARGLE","GARDEN","GENDER","HACKER","HACKLE","HEADER","HECTIC","HEALTH","HIKING","HIRING","HEIGHT","HUNGRY","HUNTER","OBTAIN","OBJECT","OFFICE","ONLINE","OMELET","ORANGE","OPTION","OPTICS","OPENER","ORPHAN","OXYGEN","OPPOSE","DAMPER","DEPORT","DERAIL","DEPUTY","DENOTE","DENIAL","DERIVE","DEVICE","DETECT","DEXTER","DUMPER","EASILY","EASIER","EFFORT","EFFECT","ENROLL","EXHALE","EXPECT","EXOTIC","EXPAND","EXPORT","ICONIC","IDEATE","IDIOMS","IMPAIR","IMPORT","INCOME","INDEED","INHALE","ISLAND","INTERN","INSIDE",
                              
                           };
        String[] BigRData ={"ACTINO","ALUMIN","SUGUAT","CSPEAT","ASPEEL","ATRESR","AIRRVE","ATCENS","ARITST","OINMRS","TOMION","MOTVIE","MOTEHR","MYFELS","EUSCLM","RURDEM","MASETR","MTTANU","APRROT","MODYFI","MRIROR","MISTRE","MIYERS","MOSLTY","BBBULE","BUTRET","BRAKEE","NABNER","LANGBE","BEMOCE","BIRANY","BITETR","TIBING","BRGIHT","BRIEGD","LUNDBE","BAFRIC","FAOTCR","FACILA","MARFER","FTUURE","FISHRE","SIFCAL","FIRYLM","FIRGNI","UFTILE","IUMFNG","LUFFIL","FOTGER","EONDFR","FLITHG","IINFSH","EACKPT","EADDLP","PACYFI","PICNCI","PICARY","PUZLZE","PISOTL","PLULAR","PRAYEL","PARNOD","PLTROA","PHNTOO","ELPDGE","KELTTE","KIDANP","LIKLER","YIDNEK","KELVNI","NANKIP","NRRAOW","NAITVE","NTAION","NARUTE","HEPNEW","TESNED","OOTINN","ENPHEW","EESTLN","OONDLE","NZOZLE","NOYART","ACLORY","CENDLA","CANLEC","CSNVAA","CAERER","CANBOR","GMABIT","GAMLBE","GELTNY","RLIDEG","GILTCH","GEERDY","GARGAE","GAEGLR","RAGDEN","GERDEN","HARKEC","AHCKLE","EEADHR","HEITCC","HEALHT","HIGINK","HIRGNI","HEIHGT","NUHGRY","HUTNER","TBOAIN","OBCEJT","OEFICF","ENLINO","EMOLET","ONARGE","NPTIOO","OPTISC","OPRNEE","ORHPAN","ONYGEX","POPOSE","DEMPAR","DPEORT","DERIAL","DEPTUY","DEEOTN","LENIAD","DEEIVR","DEVCIE","TETECD","DXETER","DMUPER","AESILY","EASEIR","EFFTRO","ECFEFT","NEROLL","EEHALX","EXPCET","EOXTIC","EXNAPD","TXPORE","CIONIC","IEDATE","IDSOMI","IRPAIM","IOPMRT","CNIOME","DNIEED","ILHANE","NSLAID","IRTENN","SNIIDE",
                              };
        int score = 10;
        int lives = 10;
        int[] stat = { 0, 0, 0, 0, 0, 0, 1, 1 };
        String[] data = new String[8];
        String[] data1 = new String[8];
        int prevRow = 99;
        int prevCol = 99;
        int curRow, curCol;
        Button rep;
        Random rnd = new Random();
        private void myTimer_tick(Object sender, Object e)
        {
            Button[,] B = {{ b00, b01, b02, b03, b04, b05 },
                            { b10, b11, b12, b13, b14, b15 },
                            { b20, b21, b22, b23, b24, b25 },
                            { b30, b31, b32, b33, b34, b35 },
                            { b40, b41, b42, b43, b44, b45 },
                            { b50, b51, b52, b53, b54, b55 },
                            { b60, b61, b62, b63, b64, b65 },
                            { b70, b71, b72, b73, b74, b75 },
                           };
            if (stat[7] != 1) lives -= 1;
            sc1.Text = "Score : " + score;
            liv.Text = "Lives : " + lives;
            if (lives == 0)
            { 
                myTimer.Stop(); 
            }
            for (int i = 7; i>0;i--)
            {
                data[i] = data[i - 1];
            }
            for (int i = 7; i > 0; i--)
            {
                data1[i] = data1[i - 1];
            }
            for (int i = 7; i > 0; i--)
            {
                stat[i] = stat[i - 1];
            }
            stat[0] = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                    B[i, j].Background = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if(stat[i]==1)
                        B[i, j].Background = new SolidColorBrush(Windows.UI.Colors.Green);
                }
            }
            int result = rnd.Next(0, 145);
            data[0] = BigRData[result];
            data1[0] = BigData[result];
            prevRow++;
            if(prevRow<=7)
            {
                if(stat[prevRow]==0)
                    B[prevRow,prevCol].Background = new SolidColorBrush(Windows.UI.Colors.Blue);
                if (stat[prevRow] == 1)
                    B[prevRow, prevCol].Background = new SolidColorBrush(Windows.UI.Colors.Green);
                if (stat[prevRow - 1] == 0)
                    B[prevRow - 1, prevCol].Background = new SolidColorBrush(Windows.UI.Colors.Red);
                if (stat[prevRow - 1] == 1)
                    B[prevRow - 1, prevCol].Background = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            if (prevRow == 8) 
            {
                if(stat[prevRow-1]==0)
                    B[prevRow-1, prevCol].Background = new SolidColorBrush(Windows.UI.Colors.Red);
                if (stat[prevRow - 1] == 1)
                    B[prevRow - 1, prevCol].Background = new SolidColorBrush(Windows.UI.Colors.Green);
                prevRow = 99; prevCol = 99; }
       
            load();

        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
        
        private void init()
        {
            int result;
            for(int i=0;i<6;i++)
            {
                result = rnd.Next(0, 145);
                data[i] = BigRData[result];
                data1[i] = BigData[result];
            }
            data[6] = "      ";
            data[7] = "      ";
        }

        private async void load()
        {
            b00.Content = data[0][0];
            b01.Content = data[0][1];
            b02.Content = data[0][2];
            b03.Content = data[0][3];
            b04.Content = data[0][4];
            b05.Content = data[0][5];
            b10.Content = data[1][0];
            b11.Content = data[1][1];
            b12.Content = data[1][2];
            b13.Content = data[1][3];
            b14.Content = data[1][4];
            b15.Content = data[1][5];
            b20.Content = data[2][0];
            b21.Content = data[2][1];
            b22.Content = data[2][2];
            b23.Content = data[2][3];
            b24.Content = data[2][4];
            b25.Content = data[2][5];
            b30.Content = data[3][0];
            b31.Content = data[3][1];
            b32.Content = data[3][2];
            b33.Content = data[3][3];
            b34.Content = data[3][4];
            b35.Content = data[3][5];
            b40.Content = data[4][0];
            b41.Content = data[4][1];
            b42.Content = data[4][2];
            b43.Content = data[4][3];
            b44.Content = data[4][4];
            b45.Content = data[4][5];
            b50.Content = data[5][0];
            b51.Content = data[5][1];
            b52.Content = data[5][2];
            b53.Content = data[5][3];
            b54.Content = data[5][4];
            b55.Content = data[5][5];
            b60.Content = data[6][0];
            b61.Content = data[6][1];
            b62.Content = data[6][2];
            b63.Content = data[6][3];
            b64.Content = data[6][4];
            b65.Content = data[6][5];
            b70.Content = data[7][0];
            b71.Content = data[7][1];
            b72.Content = data[7][2];
            b73.Content = data[7][3];
            b74.Content = data[7][4];
            b75.Content = data[7][5];
        }

        private async void checkScore(int rown)
        {
            if (data[rown] == data1[rown])
            {
                stat[rown] = 1;
                lives += 2;
                t = t * 0.40;
                if (lives > score) score = lives;
            }
            sc1.Text = "Score : " + score;
            liv.Text = "Lives : " + lives;
            Button[,] B = {{ b00, b01, b02, b03, b04, b05 },
                            { b10, b11, b12, b13, b14, b15 },
                            { b20, b21, b22, b23, b24, b25 },
                            { b30, b31, b32, b33, b34, b35 },
                            { b40, b41, b42, b43, b44, b45 },
                            { b50, b51, b52, b53, b54, b55 },
                            { b60, b61, b62, b63, b64, b65 },
                            { b70, b71, b72, b73, b74, b75 },
                           };
            for (int i = 0; i < 6; i++)
            {
                if(stat[rown]==1)
                    B[rown, i].Background = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }
        private async void tap(object sender, RoutedEventArgs e)
        {
            Button[,] B = {{ b00, b01, b02, b03, b04, b05 },
                            { b10, b11, b12, b13, b14, b15 },
                            { b20, b21, b22, b23, b24, b25 },
                            { b30, b31, b32, b33, b34, b35 },
                            { b40, b41, b42, b43, b44, b45 },
                            { b50, b51, b52, b53, b54, b55 },
                            { b60, b61, b62, b63, b64, b65 },
                            { b70, b71, b72, b73, b74, b75 },
                           };
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                    B[i, j].Background = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (stat[i] == 1)
                        B[i, j].Background = new SolidColorBrush(Windows.UI.Colors.Green);
                }
            }
            Button b1 = sender as Button;
            String s=b1.Name;
            curRow = (int)(s[1]-'0');
            curCol = (int)(s[2]-'0');
            if (stat[curRow] == 0)
                b1.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            if (stat[curRow] == 0)
            {
                if (prevRow < 10 && prevCol < 10)
                {
                    if (prevRow == curRow)
                    {
                        char[] a = { 'a', 'a', 'a', 'a', 'a', 'a' };
                        char a1 = data[curRow][curCol];
                        char a2 = data[prevRow][prevCol];
                        for (int i = 0; i < 6; i++)
                        {
                            if (i == curCol) a[i] = a2;
                            else if (i == prevCol) a[i] = a1;
                            else a[i] = data[curRow][i];
                        }
                        String stmp = new String(a);
                        data[curRow] = stmp;
                        load();
                        checkScore(curRow);
                        prevRow = 99; prevCol = 99;
                        b1.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                        rep.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                    else
                    {
                        prevRow = 99; prevCol = 99;
                        b1.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                        rep.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                }
                else
                {
                    prevRow = curRow;
                    prevCol = curCol;
                    rep = b1;
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (stat[i] == 1)
                            B[i, j].Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    }
                }
            }
            else
            {
                if (prevRow < 10 && prevCol < 10)    
                B[prevRow, prevCol].Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            }
        }
    }
}
