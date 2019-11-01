using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

public class OutsideView : StatefulWidget
{
    public override State createState()
    {
        return new OutsideViewState();
    }
}
public class OutsideViewState : State<OutsideView>
{
    private int currentIndex = -1;
    private int prvIndex = -1;
    public override Widget build(BuildContext context)
    {
        return new Container(
            child: new ListView(
                children: new List<Widget>()
                {
                    new Container(//s系列
                    padding:EdgeInsets.only(20,10,20,10),
                    child:new Column(
                        children:new List<Widget>()
                        {
                            new ItemView("a7000(outside)",0,currentIndex,Colors.blue,index=>{prvIndex=currentIndex;setState(()=>{currentIndex=index; }); }),
                        }
                        )
                    ),
                    new Container(//a系列

                    )
                }
            )
            );
    }

}
