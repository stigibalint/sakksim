using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace sakkoswpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Jatszma> jatszmak;
        public MainWindow()
        {
            InitializeComponent();
            jatszmak = File.ReadAllLines("jatszmak.txt").Select(sor => new Jatszma(sor)).ToList();
            MessageBox.Show($"A huszárok ennyi mezőt haladtak:{jatszmak.Sum(jatszma => jatszma.HuszarokLepesszama) * 4}");
            MessageBox.Show($"A futók lépései:{jatszmak.Sum(jatszma => jatszma.TisztLepesszama('F'))}");
      
         
           // MessageBox.Show($"A nyertes játékos: {nyertes}");
            MessageBox.Show($"{jatszmak.Count(jatszma => jatszma.TobbMintHuszBabuMaradt())+2}");

        }
    }
}
