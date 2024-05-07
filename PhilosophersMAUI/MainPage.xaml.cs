using Microsoft.Maui.Graphics.Text;
using Microsoft.Maui.Layouts;
using Contracts;
using PhilosophersMAUI;

namespace PhilosophersMAUI
{
    public partial class MainPage : ContentPage
    {
        Color[] CurrentTheme = Themes.Theme2;

        public void ChangeThemeTo2()
        {
            CurrentTheme = Themes.Theme2;
        }
        public void ChangeThemeTo1()
        {
            CurrentTheme = Themes.Theme1;
        }

        public void ChangeState(object? sender, int buttonId, TableUI table)
        {
            if (table.states[buttonId] == States.Wait)
            {
                return;
            }
            else if(table.states[buttonId] == States.Eat) 
            {
                table.states[buttonId] = States.Think;
            }
            else 
            {
                table.states[buttonId] = States.Eat;
            }
            if (sender is Button n)
            {
                n.BackgroundColor = CurrentTheme[(int)table.states[buttonId]];
            }
        }

        /*EventHandler ChangeColor(int buttonId)
        {
            
            EventHandler handler = (object? sender, EventArgs e) =>
            {
                if (sender is Button n)
                {
                    numbers[buttonId] = (numbers[buttonId]+1) % CurrentTheme.Length;
                    n.BackgroundColor = CurrentTheme[numbers[buttonId]];
                    n.TextColor = CurrentTheme[numbers[buttonId]];
                }
            };
            return handler;
        }*/

        public MainPage()
        {
            InitializeComponent();

            var table = new TableUI(7,80,30,400);
            /*table.action += (object? sender, int buttonId) =>
            {
                if (sender is Button n)
                {
                    colors[buttonId] = (colors[buttonId] + 1) % CurrentTheme.Length;    
                    n.BackgroundColor = CurrentTheme[colors[buttonId]];
                    n.TextColor = CurrentTheme[colors[buttonId]];
                }
            };*/
            table.action += (object? sender, int buttonId) =>
            {
                ChangeState(sender, buttonId, table);
            };
            var tableLayout = table.GetLayout;
            tableLayout.VerticalOptions = LayoutOptions.Center;
            tableLayout.HorizontalOptions = LayoutOptions.Center;

            /*Button iterateButton = new Button
            {
                Text = "Iterate",
                BackgroundColor = Colors.Black,
                TextColor = Colors.White,
                CornerRadius = 30,
                HeightRequest = 75,
                WidthRequest = 150,
                Margin = 50,
                VerticalOptions = LayoutOptions.End
            };

            var functionalStack = new VerticalStackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Margin = 50
            };

            functionalStack.Add(tableLayout);
            //functionalStack.Add(iterateButon);
            mainLayout.Add(functionalStack, 0, 0);

            Layout descriptionCanvas = new VerticalStackLayout
            {
                BackgroundColor = Colors.Black,
                Spacing = 25,
            };
            descriptionCanvas.Add(new Label
            { 
                Text = "Title",
                TextColor = Colors.White,
                Margin= 50,
                FontSize = 36,
                FontAttributes = FontAttributes.Bold
            });
            descriptionCanvas.Add(new Label 
            { 
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                TextColor = Colors.White,
                Margin = 50,
                FontSize = 18
            });
            Button loadDllButton = new Button
            {
                Text = "Load DLL",
                TextColor = Colors.White,
                CornerRadius = 30,
                HeightRequest = 75,
                WidthRequest = 150,
                Margin = 50,
                VerticalOptions = LayoutOptions.End
            };
            //descriptionCanvas.Add(loadDllButton);
            mainLayout.Add(descriptionCanvas, 1, 0);

            mainLayout.Add(iterateButton, 0, 1);
            mainLayout.Add(loadDllButton, 1, 1);

            mainLayout.BackgroundColor = Colors.White;

            var scroll = new ScrollView
            {
                Content = mainLayout
            };*/

            functionalStack.Add(tableLayout);

        }
    }
}
