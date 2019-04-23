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

        private readonly String HOTEL_URI = "images/hotel.png";
        private readonly String HOUSE_URI = "images/house.png";
        
        // We are using these as resources only. May not hurt to transition these to a static class...
        private Image _HotelImage = new Image();
        private Image _HouseImage = new Image();

        private Image _Hotel;
        private List<Image> _Houses;


        
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
            if(_Hotel == null)
            {
                _Hotel = _HotelImage;
            }
        }

        public void RemoveHotel()
        {
            if(_Hotel != null)
            {
                _Hotel = null;
            }
        }

        public void AddHouse()
        {
            if (_Houses.Count <= 3)
            {
                _Houses.Add(_HouseImage);
            }
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
