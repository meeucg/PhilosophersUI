﻿using PhilosophersMAUI;
using Contracts;

public class TableUI
{
    public delegate void Action(object? sender, int buttonId);
    public event Action? action;

    private Button[] buttons;
    private Button[] forks;
    private Layout layout;

    public Layout GetLayout { get => layout; }
    public int PhilosophersCount { get; private set; }
    public States[] states { get; private set; }

    EventHandler OnClicked(int buttonId)
    {
        EventHandler handler = (object? sender, EventArgs e) =>
        {
            action?.Invoke(sender, buttonId);
        };
        return handler;
    }

    public Layout GenerateLayout(int size)
    {
        CircularLayoutManager clm = new(size);

        for(int i = 0; i < PhilosophersCount; i++)
        {
            clm.Add(buttons[i]);
            clm.Add(forks[i]);
        }
        return clm.GetLayout;
    }

    public TableUI(int philosophersCount, int buttonSize, int forkSize, int layoutSize)
    {
        PhilosophersCount = philosophersCount;
        states = new States[PhilosophersCount];
        buttons = new Button[philosophersCount];
        forks = new Button[philosophersCount];

        for (int i = 0; i < philosophersCount; i++)
        {
            buttons[i] = new Button()
            { 
                HeightRequest = buttonSize,
                WidthRequest = buttonSize,
                CornerRadius = buttonSize,
                BackgroundColor = Themes.CurrentTheme[0],
                BorderWidth = 15,
                BorderColor = Themes.CurrentTheme[0]
            };
            buttons[i].Clicked += OnClicked(i);
            forks[i] = new Button()
            {
                HeightRequest = forkSize,
                WidthRequest = forkSize,
                CornerRadius = forkSize,
                IsEnabled = false,
                BackgroundColor = Themes.CurrentTheme[2],
            };
        }
        layout = GenerateLayout(layoutSize);
    }
}
