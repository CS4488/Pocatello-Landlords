using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Monopoly_Game
{
    public class BuildableProperty : Property
    {
        /// <summary>
        /// Created by Fernando Munoz
        /// This class will be utilized whenever we need/want to make a space buildable with houses or hotels
        /// </summary>

        private readonly String HOTEL_URI = "images/hotel.jpg";
        private readonly String HOUSE_URI = "images/house2.jpg";
        
        // We are using these as resources only. May not hurt to transition these to a static class...
        private Image _HotelImage = new Image();
        private Image _HouseImage = new Image();

        private Image _Hotel;
        private List<Image> _Houses = new List<Image>();


        
        public BuildableProperty(string id, TextBlock name, Button btn, WrapPanel moveArea, StackPanel bldgArea, TextBlock valueTB) : base(id, name, btn, moveArea,bldgArea, valueTB)
        {
            SetupImages();
        }

        public List<Image> Houses
        {
            get { return _Houses; }
            set { _Houses = value; }
        }
        
        public Image Hotel
        {
            get { return _Hotel; }
            set { _Hotel = value; }
        }

        private void SetupImages()
        {
            _HotelImage.Source = SetupBitMap(HOTEL_URI);
            _HouseImage.Source = SetupBitMap(HOUSE_URI);
        }

        private BitmapImage SetupBitMap(string uri)
        {
            BitmapImage bm = new BitmapImage();
            bm.BeginInit();
            bm.UriSource = new Uri(uri, UriKind.Relative);
            bm.EndInit();
            return bm;
        }

        public void AddHotel()
        {
            if (_Houses.Count == 4)
            {
                _Hotel = _HouseImage;
                base.BuildingArea.Children.Clear();
                Image temp = new Image();
                temp.Source = SetupBitMap(HOTEL_URI);
                base.BuildingArea.Children.Add(temp);
            }
        }

        public void RemoveHotel( )
        {

        }

        public void Build()
        {
            if (_Houses.Count <= 3)
            {
                _Houses.Add(_HouseImage);
                base.BuildingArea.Children.Clear();
                foreach (Image i in _Houses)
                {
                    Image temp = new Image();
                    temp.Source = SetupBitMap(HOUSE_URI);
                    base.BuildingArea.Children.Add(temp);
                }
            }
            else if(_Houses.Count == 4)
            {
                AddHotel();
            }
        }

        public int BuildCost()
        {
            if(_Houses.Count <= 4 && _Hotel == null)
            {
                return (base.Value / 4) + (base.Value / 2 * _Houses.Count);
            }
            return -1;
            
        }

        public void RemoveHouse()
        {
            if(_Houses.Count > 0)
            {
                _Houses.Remove(_HouseImage);
            }
        }

        public void RemoveHouse(int num)
        {
            if(_Houses.Count >= num)
            {
                while(num > 0)
                {
                    RemoveHouse();
                    num--;
                }
            }
        }

        
    }
}
