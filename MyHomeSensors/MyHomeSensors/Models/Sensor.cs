using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyHomeSensors.Models
{
    public class Sensor
    {
        public ObservableCollection<KeyPair> Values { get; set; }
    }
}
