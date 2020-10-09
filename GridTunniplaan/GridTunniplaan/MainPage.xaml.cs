using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace GridTunniplaan
{
    public partial class MainPage : ContentPage
    {
        const int ColumnNumber = 10;
        const int RowNumber = 6;
        private string[] weekDaysNames;
        private string[] lessonTitles;
        private int[] lessonLengths;
        private int[] lessonDayOfWeek;
        private int[] lessonStarts;
        private Color[] lessonColors;

        public MainPage()
        {
            Title = "Tunniplaan";
            weekDaysNames = new string[5] { "Esmaspäev", "Teisipäev", "Kolmapäev", "Neljapäev", "Reede" };
            lessonTitles = new string[]
            {
                "Keel ja kirjandus", "Võrgud ja seadmed", "Mobiilirakendused", "Transpordilogistika juhtimine", "Inglise keel (win. hald)", "Eesti keel teise keelena",
                "Windows paigaldus ja seadistus", "Transpordi logistika juhtimine", "Keemia ja bioloogia", "Windows paigaldjus ja seadistus", "Võrgud ja seadmed",
                "Inglise keel (win. hald)", "Keemia ja bioloogia", "Mobiilirakendused"
            };
            lessonLengths = new int[] { 2, 2, 3, 3, 2, 2, 3, 5, 1, 3, 2, 2, 1, 3 };
            lessonDayOfWeek = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5 };
            lessonStarts = new int[] { 1, 3, 6, 1, 5, 7, 1, 4, 9, 1, 5, 7, 1, 3 };
            lessonColors = new Color[]
            {
                Color.Green, Color.LightPink, Color.DeepSkyBlue, Color.DarkSeaGreen, Color.Gray, Color.DeepPink,
                Color.MediumPurple, Color.DarkSeaGreen, Color.Purple, Color.MediumPurple, Color.LightPink, Color.Gray,
                Color.Purple, Color.DeepSkyBlue
            };

            Grid timetable = new Grid();
            for (int i = 0; i < ColumnNumber; i++)
            {
                timetable.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < RowNumber; i++)
            {
                timetable.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < ColumnNumber; i++)
            {
                Label lessonNumberLabel = new Label()
                {
                    Text = i.ToString(),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                };
                BoxView lessonNumberBoxView = new BoxView()
                {
                    BackgroundColor = Color.White
                };
                timetable.Children.Add(lessonNumberBoxView, 1 + i, 0);
                timetable.Children.Add(lessonNumberLabel, 1 + i, 0);
            }

            foreach (string weekDayName in weekDaysNames)
            {
                Label weekDayLabel = new Label()
                {
                    Text = weekDayName,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                };
                BoxView weekDayBoxView = new BoxView()
                {
                    BackgroundColor = Color.White
                };
                timetable.Children.Add(weekDayBoxView, 0, 1 + weekDaysNames.IndexOf(weekDayName));
                timetable.Children.Add(weekDayLabel, 0, 1 + weekDaysNames.IndexOf(weekDayName));
            }

            for (int i = 0; i < lessonTitles.Count(); i++)
            {
                Label lessonTitleLabel = new Label()
                {
                    Text = lessonTitles[i],
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                };
                BoxView lessonBoxView = new BoxView()
                {
                    Color = lessonColors[i]
                };
                timetable.Children.Add(lessonBoxView, 1 + lessonStarts[i], lessonDayOfWeek[i]);
                timetable.Children.Add(lessonTitleLabel, 1 + lessonStarts[i], lessonDayOfWeek[i]);
                Grid.SetColumnSpan(lessonBoxView, lessonLengths[i]);
                Grid.SetColumnSpan(lessonTitleLabel, lessonLengths[i]);
            }

            Label timeTableTitle = new Label()
            {
                Text = Title,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            };
            BoxView timeTableTitleBoxView = new BoxView()
            {
                Color = Color.White
            };
            timetable.Children.Add(timeTableTitleBoxView, 0, 0);
            timetable.Children.Add(timeTableTitle, 0, 0);
            timetable.HorizontalOptions = LayoutOptions.FillAndExpand;
            timetable.VerticalOptions = LayoutOptions.FillAndExpand;
            timetable.RowSpacing = 2;
            timetable.ColumnSpacing = 2;
            timetable.BackgroundColor = Color.Silver;
            StackLayout timeTableLayout = new StackLayout()
            {
                Children = { timetable }
            };
            Content = timeTableLayout;
        }
    }
}