using Bonsai;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Bonsai.Harp;

[Combinator]
[Description("Constructs a Harp message to set the Tilt mechanism limits (-ve, +ve) from a Tuple<-ve, +ve>")]
[WorkflowElementCategory(ElementCategory.Transform)]
public class CreatePositionLimits
{

    private int address = 41;
    public int Address
    {
        get { return address; }
        set { address = value; }
    }
    
    public IObservable<HarpMessage> Process(IObservable<Tuple<int, int>> source)
    {
        return source.Select(value => {
            var message = HarpMessage.FromInt16(address, MessageType.Write, Convert.ToInt16(value.Item1), Convert.ToInt16(value.Item2));
            return message;
        });
    }
}
