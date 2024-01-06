using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Barbershop
{
    /// <summary>
    /// Логика взаимодействия для Glavform.xaml
    /// </summary>
    public partial class Glavform : Window
    {

        XDocument doc1;
        XDocument doc2;
        XDocument doc3;
        public ObservableCollection<object> HAIRSCollection;
        public ObservableCollection<object> CLIENTSCollection;
        public ObservableCollection<object> WORKSCollection;

        private int counter = 0;

        private bool yn = false;

        public Glavform()
        {
            InitializeComponent();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            counter = 1;

            dobavlenie1.Visibility = Visibility.Visible;
            dobavlenie2.Visibility = Visibility.Visible;
            dobavlenie3.Visibility = Visibility.Visible;
            dobavlenie4.Visibility = Visibility.Visible;
            dobavlenie5.Visibility = Visibility.Hidden;
            dobavlenie6.Visibility = Visibility.Hidden;
            img1.Visibility = Visibility.Hidden;
            img2.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Visible;
            Hairs.Visibility = Visibility.Visible;
            Clients.Visibility = Visibility.Hidden;
            Works.Visibility = Visibility.Hidden;

            doc1 = XDocument.Load("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Hairs.xml");
            var HAIRS = (from x in doc1.Element("Hairs").Elements("Hair")
                         orderby x.Element("KodS").Value
                         select new
                         {
                             Код = x.Element("KodS").Value,
                             Название = x.Element("Name").Value,
                             Пол = x.Element("Gender").Value,
                             Цена = x.Element("Price").Value

                         }).ToList();

            var HAIRSCollection = new ObservableCollection<object>(HAIRS);
            dg.ItemsSource = HAIRSCollection;
        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            counter = 2;

            dobavlenie1.Visibility = Visibility.Visible;
            dobavlenie2.Visibility = Visibility.Visible;
            dobavlenie3.Visibility = Visibility.Visible;
            dobavlenie4.Visibility = Visibility.Visible;
            dobavlenie5.Visibility = Visibility.Visible;
            dobavlenie6.Visibility = Visibility.Visible;
            img1.Visibility = Visibility.Hidden;
            img2.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Visible;
            Hairs.Visibility = Visibility.Hidden;
            Clients.Visibility = Visibility.Visible;
            Works.Visibility = Visibility.Hidden;

            doc2 = XDocument.Load("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Clients.xml");
            var CLIENTS = (from x in doc2.Element("Clients").Elements("Client")
                           orderby x.Element("KodC").Value
                           select new
                           {
                               Код = x.Element("KodC").Value,
                               Фамилия = x.Element("Surname").Value,
                               Имя = x.Element("NameC").Value,
                               Отчество = x.Element("MiddleName").Value,
                               Пол = x.Element("Gender").Value,
                               ПостКлиент = x.Element("PostC").Value
                           }).ToList();

            var CLIENTSCollection = new ObservableCollection<object>(CLIENTS);
            dg.ItemsSource = CLIENTSCollection;
        }

        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            counter = 3;

            dobavlenie1.Visibility = Visibility.Visible;
            dobavlenie2.Visibility = Visibility.Visible;
            dobavlenie3.Visibility = Visibility.Visible;
            dobavlenie4.Visibility = Visibility.Visible;
            dobavlenie5.Visibility = Visibility.Hidden;
            dobavlenie6.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Visible;
            img1.Visibility = Visibility.Hidden;
            img2.Visibility = Visibility.Hidden;
            Hairs.Visibility = Visibility.Hidden;
            Clients.Visibility = Visibility.Hidden;
            Works.Visibility = Visibility.Visible;

            doc3 = XDocument.Load("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Works.xml");
            var WORKS = (from x in doc3.Element("Works").Elements("Work")
                         orderby x.Element("KodR").Value
                         select new
                         {
                             Код_Работы = x.Element("KodR").Value,
                             Код_Стрижки = x.Element("KodS").Value,
                             Код_Клиента = x.Element("KodC").Value,
                             Дата = x.Element("Date").Value,

                         }).ToList();

            var WORKSCollection = new ObservableCollection<object>(WORKS);
            dg.ItemsSource = WORKSCollection;
        }

        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            add.Visibility = Visibility.Visible;
            edit.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Hidden;
            search.Visibility = Visibility.Hidden;
        }

        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            add.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Visible;
            del.Visibility = Visibility.Hidden;
            search.Visibility = Visibility.Hidden;
        }

        private void MenuItemDel_Click(object sender, RoutedEventArgs e)
        {
            add.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Visible;
            search.Visibility = Visibility.Hidden;
        }

        private void MenuItemSearch_Click(object sender, RoutedEventArgs e)
        {
            add.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Hidden;
            search.Visibility = Visibility.Visible;
        }

        private void buttonadd_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                doc1.Element("Hairs").Add(new XElement("Hair",
                    new XElement("KodS", dobavlenie1.Text),
                    new XElement("Name", dobavlenie2.Text),
                    new XElement("Gender", dobavlenie3.Text),
                    new XElement("Price", dobavlenie4.Text)));

                doc1.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Hairs.xml");

                MessageBox.Show("Новые данные добавлены!");

                var HAIRS = (from x in doc1.Element("Hairs").Elements("Hair")
                             orderby x.Element("KodS").Value
                             select new
                             {
                                 Код = x.Element("KodS").Value,
                                 Название = x.Element("Name").Value,
                                 Пол = x.Element("Gender").Value,
                                 Цена = x.Element("Price").Value

                             }).ToList();

                var HAIRSCollection = new ObservableCollection<object>(HAIRS);
                dg.ItemsSource = HAIRSCollection;

            }

            if (counter == 2)
            {
                doc2.Element("Clients").Add(new XElement("Client",
                    new XElement("KodC", dobavlenie1.Text),
                    new XElement("Surname", dobavlenie2.Text),
                    new XElement("NameC", dobavlenie3.Text),
                    new XElement("MiddleName", dobavlenie4.Text),
                    new XElement("Gender", dobavlenie5.Text),
                    new XElement("PostC", dobavlenie6.Text)));

                doc2.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Clients.xml");

                MessageBox.Show("Новые данные добавлены!");

                var CLIENTS = (from x in doc2.Element("Clients").Elements("Client")
                               orderby x.Element("KodC").Value
                               select new
                               {
                                   Код = x.Element("KodC").Value,
                                   Фамилия = x.Element("Surname").Value,
                                   Имя = x.Element("NameC").Value,
                                   Отчество = x.Element("MiddleName").Value,
                                   Пол = x.Element("Gender").Value,
                                   ПостКлиент = x.Element("PostC").Value

                               }).ToList();

                var CLIENTSCollection = new ObservableCollection<object>(CLIENTS);
                dg.ItemsSource = CLIENTSCollection;

            }

            if (counter == 3)
            {
                doc3.Element("Works").Add(new XElement("Work",
                    new XElement("KodR", dobavlenie1.Text),
                    new XElement("KodS", dobavlenie2.Text),
                    new XElement("KodC", dobavlenie3.Text),
                    new XElement("Date", dobavlenie4.Text)));

                doc3.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Works.xml");

                MessageBox.Show("Новые данные добавлены!");

                var WORKS = (from x in doc3.Element("Works").Elements("Work")
                             orderby x.Element("KodR").Value
                             select new
                             {
                                 Код_Работы = x.Element("KodR").Value,
                                 Код_Стрижки = x.Element("KodS").Value,
                                 Код_Клиента = x.Element("KodC").Value,
                                 Дата = x.Element("Date").Value,

                             }).ToList();

                var WORKSCollection = new ObservableCollection<object>(WORKS);
                dg.ItemsSource = WORKSCollection;

            }
        }
        private void buttondel_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                IEnumerable<XElement> tests =
                    from el in doc1.Elements("Hairs").Elements("Hair")
                    where (string)el.Element("KodS") == dobavlenie1.Text
                    select el;
                foreach (XElement el in tests)
                    yn = true;
                if (yn == true)
                {
                    doc1.Elements("Hairs").Elements("Hair").First(b => ((string)b.Element("KodS")) == dobavlenie1.Text).Remove();

                    doc1.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Hairs.xml");

                    var HAIRS = (from x in doc1.Element("Hairs").Elements("Hair")
                                 orderby x.Element("KodS").Value
                                 select new
                                 {
                                     Код = x.Element("KodS").Value,
                                     Название = x.Element("Name").Value,
                                     Пол = x.Element("Gender").Value,
                                     Цена = x.Element("Price").Value

                                 }).ToList();

                    var HAIRSCollection = new ObservableCollection<object>(HAIRS);
                    dg.ItemsSource = HAIRSCollection;

                    MessageBox.Show("Данные удалены");
                    yn = false;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();

            }

            if (counter == 2)
            {
                IEnumerable<XElement> tests =
                    from el in doc2.Elements("Clients").Elements("Client")
                    where (string)el.Element("KodC") == dobavlenie1.Text
                    select el;
                foreach (XElement el in tests)
                    yn = true;
                if (yn == true)

                {
                    doc2.Elements("Clients").Elements("Client").First(b => ((string)b.Element("KodC")) == dobavlenie1.Text).Remove();

                    doc2.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Clients.xml");

                    var CLIENTS = (from x in doc2.Element("Clients").Elements("Client")
                                   orderby x.Element("KodC").Value
                                   select new
                                   {
                                       Код = x.Element("KodC").Value,
                                       Фамилия = x.Element("Surname").Value,
                                       Имя = x.Element("NameC").Value,
                                       Цена = x.Element("MiddleName").Value,
                                       Пол = x.Element("Gender").Value,
                                       ПостКлиент = x.Element("PostC").Value

                                   }).ToList();

                    var CLIENTSCollection = new ObservableCollection<object>(CLIENTS);
                    dg.ItemsSource = CLIENTSCollection;

                    MessageBox.Show("Данные удалены");

                }
                else
                {
                    MessageBox.Show("Ошибка");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();

            }

            if (counter == 3)
            {
                IEnumerable<XElement> tests =
                    from el in doc3.Elements("Works").Elements("Work")
                    where (string)el.Element("KodR") == dobavlenie1.Text
                    select el;
                foreach (XElement el in tests)
                    yn = true;
                if (yn == true)

                {
                    doc3.Elements("Works").Elements("Work").First(b => ((string)b.Element("KodR")) == dobavlenie1.Text).Remove();

                    doc3.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Works.xml");

                    var WORKS = (from x in doc3.Element("Works").Elements("Work")
                                 orderby x.Element("KodR").Value
                                 select new
                                 {
                                     Код_Работы = x.Element("KodR").Value,
                                     Код_Стрижки = x.Element("KodS").Value,
                                     Код_Клиента = x.Element("KodC").Value,
                                     Дата = x.Element("Date").Value,

                                 }).ToList();

                    var WORKSCollection = new ObservableCollection<object>(WORKS);
                    dg.ItemsSource = WORKSCollection;

                    MessageBox.Show("Данные удалены");

                }
                else
                {
                    MessageBox.Show("Ошибка");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();

            }
        }

        private void buttonedit_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                IEnumerable<XElement> tests =
                    from el in doc1.Elements("Hairs").Elements("Hair")
                    where (string)el.Element("KodS") == dobavlenie1.Text
                    select el;
                foreach (XElement el in tests)
                    yn = true;
                if (yn == true)

                {
                    doc1.Elements("Hairs").Elements("Hair").First(b => ((string)b.Element("KodS")) == dobavlenie1.Text).SetElementValue("Name", dobavlenie2.Text);
                    doc1.Elements("Hairs").Elements("Hair").First(b => ((string)b.Element("KodS")) == dobavlenie1.Text).SetElementValue("Gender", dobavlenie3.Text);
                    doc1.Elements("Hairs").Elements("Hair").First(b => ((string)b.Element("KodS")) == dobavlenie1.Text).SetElementValue("Price", dobavlenie4.Text);

                    doc1.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Hairs.xml");

                    var HAIRS = (from x in doc1.Element("Hairs").Elements("Hair")
                                 orderby x.Element("KodS").Value
                                 select new
                                 {
                                     Код = x.Element("KodS").Value,
                                     Название = x.Element("Name").Value,
                                     Пол = x.Element("Gender").Value,
                                     Цена = x.Element("Price").Value

                                 }).ToList();

                    var HAIRSCollection = new ObservableCollection<object>(HAIRS);
                    dg.ItemsSource = HAIRSCollection;

                    MessageBox.Show("Данные отредактированы");

                }
                else
                {
                    MessageBox.Show("Ошибка");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }

            if (counter == 2)
            {
                IEnumerable<XElement> tests =
                    from el in doc2.Elements("Clients").Elements("Cleint")
                    where (string)el.Element("KodC") == dobavlenie1.Text
                    select el;
                foreach (XElement el in tests)
                    yn = true;
                if (yn == true)

                {
                    doc2.Elements("Clients").Elements("Client").First(b => ((string)b.Element("KodC")) == dobavlenie1.Text).SetElementValue("Surname", dobavlenie2.Text);
                    doc2.Elements("Clients").Elements("Client").First(b => ((string)b.Element("KodC")) == dobavlenie1.Text).SetElementValue("NameC", dobavlenie3.Text);
                    doc2.Elements("Clients").Elements("Client").First(b => ((string)b.Element("KodC")) == dobavlenie1.Text).SetElementValue("MiddleName", dobavlenie4.Text);
                    doc2.Elements("Clients").Elements("Client").First(b => ((string)b.Element("KodC")) == dobavlenie1.Text).SetElementValue("Gender", dobavlenie5.Text);
                    doc2.Elements("Clients").Elements("Client").First(b => ((string)b.Element("KodC")) == dobavlenie1.Text).SetElementValue("PostC", dobavlenie6.Text);

                    doc2.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Clients.xml");

                    var CLIENTS = (from x in doc2.Element("Clients").Elements("Client")
                                   orderby x.Element("KodC").Value
                                   select new
                                   {
                                       Код = x.Element("KodC").Value,
                                       Фамилия = x.Element("Surname").Value,
                                       Имя = x.Element("NameC").Value,
                                       Отчество = x.Element("MiddleName").Value,
                                       Пол = x.Element("Gender").Value,
                                       ПостКлиент = x.Element("PostC").Value

                                   }).ToList();

                    var CLIENTSCollection = new ObservableCollection<object>(CLIENTS);
                    dg.ItemsSource = CLIENTSCollection;

                    MessageBox.Show("Данные отредактированы");

                }
                else
                {
                    MessageBox.Show("Ошибка");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }

            if (counter == 3)
            {
                IEnumerable<XElement> tests =
                    from el in doc3.Elements("Works").Elements("Work")
                    where (string)el.Element("KodR") == dobavlenie1.Text
                    select el;
                foreach (XElement el in tests)
                    yn = true;
                if (yn == true)

                {
                    doc3.Elements("Works").Elements("Work").First(b => ((string)b.Element("KodR")) == dobavlenie1.Text).SetElementValue("KodS", dobavlenie2.Text);
                    doc3.Elements("Works").Elements("Work").First(b => ((string)b.Element("KodR")) == dobavlenie1.Text).SetElementValue("KodC", dobavlenie3.Text);
                    doc3.Elements("Works").Elements("Work").First(b => ((string)b.Element("KodR")) == dobavlenie1.Text).SetElementValue("Date", dobavlenie4.Text);

                    doc3.Save("C:\\Users\\Полоцкий Константин\\source\\repos\\Barbershop\\Barbershop\\Works.xml");

                    var WORKS = (from x in doc3.Element("Works").Elements("Work")
                                 orderby x.Element("KodR").Value
                                 select new
                                 {
                                     Код_Работы = x.Element("KodR").Value,
                                     Код_Стрижки = x.Element("KodS").Value,
                                     Код_Клиента = x.Element("KodC").Value,
                                     Дата = x.Element("Date").Value,

                                 }).ToList();

                    var WORKSCollection = new ObservableCollection<object>(WORKS);
                    dg.ItemsSource = WORKSCollection;

                    MessageBox.Show("Данные отредактированы");

                }
                else
                {
                    MessageBox.Show("Ошибка");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();

            }

        }
        private void buttonsearch_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                if (dobavlenie1 != null)
                {
                    var kod = (from x in doc1.Element("Hairs").Elements("Hair")
                               where (string)x.Element("KodS") == dobavlenie1.Text || (string)x.Element("Name") == dobavlenie2.Text || (string)x.Element("Gender") == dobavlenie3.Text || (string)x.Element("Price") == dobavlenie4.Text
                               select new
                               {
                                   Код = x.Element("KodS").Value,
                                   Название = x.Element("Name").Value,
                                   Пол = x.Element("Gender").Value,
                                   Цена = x.Element("Price").Value

                               }).ToList();

                    dg.ItemsSource = kod;
                }
                if (dobavlenie1.Text == "" && dobavlenie2.Text == "группировка" && dobavlenie3.Text == "" && dobavlenie4.Text == "")
                {
                    var type = (from x in doc1.Element("Hairs").Elements("Hair")
                                group x by x.Element("Name").Value into g
                                select new
                                {
                                    Прически = g.Key
                                }).ToList();

                    dg.ItemsSource = type;
                }

                if (dobavlenie1.Text == "" && dobavlenie3.Text != null && dobavlenie2.Text == "" && dobavlenie4.Text == "")
                {
                    var gen = (from x in doc1.Element("Hairs").Elements("Hair")
                               where (string)x.Element("Gender") == dobavlenie3.Text
                               group x by x.Element("Gender").Value into g
                               select new
                               {
                                   Прически = g.Key,
                                   Количество = g.Count()
                               }).ToList();

                    dg.ItemsSource = gen;
                }         
            }

                if (counter == 2)
                {
                    if (dobavlenie1 != null)
                    {
                        var kod1 = (from x in doc2.Element("Clients").Elements("Client")
                                   where (string)x.Element("KodC") == dobavlenie1.Text || (string)x.Element("Surname") == dobavlenie2.Text || (string)x.Element("NameC") == dobavlenie3.Text || (string)x.Element("MiddleName") == dobavlenie4.Text || (string)x.Element("Gender") == dobavlenie5.Text || (string)x.Element("PostC") == dobavlenie6.Text
                                   select new
                                   {
                                       Код = x.Element("KodC").Value,
                                       Фамилия = x.Element("Surname").Value,
                                       Имя = x.Element("NameC").Value,
                                       Отчество = x.Element("MiddleName").Value,
                                       Пол = x.Element("Gender").Value,
                                       ПостКлиент = x.Element("PostC").Value

                                   }).ToList();

                        dg.ItemsSource = kod1;
                    }

                    if (dobavlenie1.Text == "" && dobavlenie2.Text == "" && dobavlenie3.Text == "" && dobavlenie4.Text == "" && dobavlenie6.Text == "" && dobavlenie5.Text != null)
                    {
                        var gen = (from x in doc2.Element("Clients").Elements("Client")
                                   where (string)x.Element("Gender") == dobavlenie5.Text
                                   group x by x.Element("Gender").Value into g
                                   select new
                                   {
                                       Гендер = g.Key,
                                       Количество = g.Count()
                                   }).ToList();

                        dg.ItemsSource = gen;
                    }

                if (dobavlenie1.Text == "" && dobavlenie2.Text == "первый" && dobavlenie3.Text == "" && dobavlenie4.Text == "" && dobavlenie6.Text == "" && dobavlenie2.Text != null && dobavlenie5.Text == "")
                {
                    var gen = (from x in doc2.Element("Clients").Elements("Client")
                               where (string)x.Element("Surname") == dobavlenie2.Text
                               group x by x.Element("Surname").Value into g
                               select new
                               {
                                   Фамилия = g.First().Element("Surname").Value,
                               }).ToList();

                    dg.ItemsSource = gen;
                }

            }
                if (counter == 3)
                {
                    if (dobavlenie1 != null)
                    {
                        var kods = (from x in doc3.Element("Works").Elements("Work")
                                    where (string)x.Element("KodR") == dobavlenie1.Text || (string)x.Element("KodS") == dobavlenie2.Text || (string)x.Element("KodC") == dobavlenie3.Text || (string)x.Element("Date") == dobavlenie4.Text
                                    select new
                                    {
                                        Код_Работы = x.Element("KodR").Value,
                                        Код_Стрижки = x.Element("KodS").Value,
                                        Код_Клиента = x.Element("KodC").Value,
                                        Дата = x.Element("Date").Value,

                                    }).ToList();

                        dg.ItemsSource = kods;
                    }
                }
            }
        }
    }

