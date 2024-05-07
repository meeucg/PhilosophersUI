using Microsoft.Maui.Layouts;

namespace PhilosophersMAUI
{
    public class CircularLayoutManager
    {
        public CircularLayoutManager(int size) 
        { 
            layout = new()
            {
                HeightRequest = size,
                WidthRequest = size
            };
        }

        private AbsoluteLayout layout; 
        private int objectsCount = 0; //то же, что layout.Children.Count

        public Layout GetLayout { get => layout; }

        public void Add(View obj)
        { 
            layout.Add(obj);
            
            objectsCount++;
            for (int i = 0; i < objectsCount; i++)
            {
                /*double maxDimension = Math.Max(layout.Bounds.Size.Width, layout.Bounds.Size.Height);
                double sizeProportion = 0.1;*/
                AbsoluteLayout.SetLayoutFlags(obj,
                    AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds((View)layout.Children[i], 
                    new Rect(0.5+(Math.Sin(i * double.Pi * 2 / objectsCount))/2, 0.5+(Math.Cos(i * double.Pi * 2 / objectsCount))/2, 
                    obj.Width, obj.Height));
            }
        }
    }
}
