using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

public class InsideView : StatefulWidget
{

    public override State createState()
    {
        return new InsideViewState();
    }
}
public class InsideViewState:State<InsideView>
{
    private int currentIndex=-1;
    private int prvIndex=-1;
    private List<Widget> list;
    public override Widget build(BuildContext context)
    {
        list = new List<Widget>()
        {
            new ItemView("S5",0,currentIndex,Colors.blue,index=>{prvIndex=currentIndex;currentIndex=index;this.setState(); }),
            new ItemView("S8",1,currentIndex,Colors.blue,index=>{prvIndex=currentIndex;setState(()=>{currentIndex=index; }); }),
            new ItemView("S9",2,currentIndex,Colors.blue,index=>{prvIndex=currentIndex;setState(()=>{currentIndex=index; }); }),
            new ItemView("S12",3,currentIndex,Colors.blue,index=>{prvIndex=currentIndex;setState(()=>{currentIndex=index; }); }),
            new ItemView("S15",4,currentIndex,Colors.blue,index=>{prvIndex=currentIndex;setState(()=>{currentIndex=index; }); }),
            new ItemView("a4000",5,currentIndex,Colors.blue,index=>{prvIndex=currentIndex;setState(()=>{currentIndex=index; }); }),
            new ItemView("a6000",6,currentIndex,Colors.blue,index=>{prvIndex=currentIndex;setState(()=>{currentIndex=index; }); }),
            new ItemView("a7000(inside)",7,currentIndex,Colors.blue,contex=>{prvIndex=currentIndex;setState(()=>{currentIndex=prvIndex; }); }),

        };
        return new Container(
            child:ListView.builder(
                itemCount:list.Count,
                itemBuilder: (buildContext, index) => 
                {
                    return list[index];
                 }
                )
            );
    }

}
