using System;
using System.Windows.Forms;

namespace @interface
{
    public partial class Form1 : Form
    {
        //приватные системные поля.

        // Стартовая страница с выпадающими списками.
        private HomePage homePage;

        // Текущее состояние окна. Зависит от контента на форме.
        private Status status;

        // Конструктор.
        public Form1()
        {
            // Автогенерируемый код.
            InitializeComponent();

            // Инициализация домашней страницы.
            // Можно в конструктор понапихать всякой шняги.
            homePage = new HomePage();

            // Установка начального статуса.
            status = Status.HOMEPAGE;

            // Подписываем кнопочки.
            // Они не меняются просто меняется подпись на них и функционал.
            leftButton.Text = "Старт";
            rightButton.Text = "Стоп";
        }

        // Выполняется, когда форма загружается.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Controls - список со всеми штучками на нашей панели.
            // contentPanel - верхняя "панель", которая меняется.
            // Есть еще нижняя, которая не меняется и хранит кнопочки.
            contentPanel.Controls.Add(homePage);
        }
        
        // Проверка списков на заполненность.
        private bool CheckData()
        {
            // Если чел ввел не число.
            if (homePage.GetData() == null)
            {
                MessageBox.Show("В последнем поле допускаются только числа!");
                return false;
            }
            else
            {
                return !homePage.GetData().isEmpty();
            }
        }

        // Обработка нажатий на левую кнопку.
        private void leftButton_Click(object sender, EventArgs e)
        {
            // Сначала запоминаем что было на панели.
            var tmp = contentPanel.Controls[0];

            // Затем стираем верхнюю панель.
            contentPanel.Controls.Clear();


            // В зависимости от статуса, заполняем верхнюю панель нужной страницей.
            switch (status)
            {
                case Status.HOMEPAGE:

                    // Проверка на пустоту у списков.
                    if (CheckData())
                    {
                        // Создаем странцицу с таблицей.
                        contentPanel.Controls.Add(new TablePage("Таблица 1. Мониторинг параметров"));
                        
                        // Меняем статус, переименовываем кнопки.
                        status = Status.TABLE1;

                        leftButton.Text = "Таблица 2";
                        rightButton.Text = "График";
                    }
                    // Если списки пустые, ничего не меняем.
                    else
                    {
                        contentPanel.Controls.Add(tmp);
                        MessageBox.Show("Заполните все поля!");
                    }
                    
                    break;

                case Status.TABLE1:
                    // Все то же самое, только создаем другую страницу.
                    // Опять же, все можно передать через конструктор.
                    contentPanel.Controls.Add(new TablePage("Таблица 2. Сбор и обработка информации"));
                    status = Status.TABLE2;

                    leftButton.Text = "Сбор статистики";
                    rightButton.Text = "Таблица 1";
                    break;

                case Status.GRAPH:
                    // пустышка
                    contentPanel.Controls.Add(tmp);

                    leftButton.Text = "Пустышка";
                    rightButton.Text = "Таблица 1";
                    break;

                case Status.TABLE2:
                    contentPanel.Controls.Add(new HomePage());
                    status = Status.HOMEPAGE;

                    leftButton.Text = "Старт";
                    rightButton.Text = "Стоп";
                    break;
            }
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            var tmp = contentPanel.Controls[0];
            contentPanel.Controls.Clear();

            switch (status)
            {
                case Status.HOMEPAGE:
                    // зачем нужна кнопка стоп?
                    contentPanel.Controls.Add(tmp);
                    break;

                case Status.TABLE1:
                    contentPanel.Controls.Add(new GraphPage());
                    status = Status.GRAPH;

                    leftButton.Text = "Пустышка";
                    rightButton.Text = "Таблица 1";
                    break;

                case Status.GRAPH:
                    contentPanel.Controls.Add(new TablePage("Таблица 1. Мониторинг параметров"));
                    status = Status.TABLE1;

                    leftButton.Text = "Таблица 2";
                    rightButton.Text = "График";
                    break;

                case Status.TABLE2:
                    contentPanel.Controls.Add(new TablePage("Таблица 1. Мониторинг параметров"));
                    status = Status.TABLE1;

                    leftButton.Text = "Таблица 2";
                    rightButton.Text = "График";
                    break;
            }
        }
    }
}
