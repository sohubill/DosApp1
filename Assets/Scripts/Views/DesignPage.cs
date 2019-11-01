
using System;
using System.Collections.Generic;
using UIWidgets.Runtime.material;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;
using Image = Unity.UIWidgets.widgets.Image;
using Material = Unity.UIWidgets.material.Material;

static class ListConfig
{
    public static List<Widget> tabList = new List<Widget>()
    {
        new Tab(text:"室内"),
        new Tab(text:"室外")
    };
    public static List<string> itemTitleList = new List<string>(){ "开图","订单","我的"};
    public static List<IconData> itemIconList = new List<IconData>() { Icons.create, Icons.view_list, Icons.account_box };

}

public class DesignPage : StatefulWidget
{
    public override State createState()
    {
        return new DesignPageState();
    }
}
public class DesignPageState : State<DesignPage>, TickerProvider
{

    private TabController tabController;
    int currentIndex;

    public override void initState()
    {
        tabController = new TabController(
           length: 2,
           vsync: this
           );
        currentIndex = 0;
        base.initState();      
    }
    public override void dispose()
    {
        tabController.dispose();
        base.dispose();
    }
    public override Widget build(BuildContext context)
    {
        return new MaterialApp(
            title: "开图",
            theme: new ThemeData(primaryColor: Colors.blueGrey),
            home: new Scaffold(
                appBar: new AppBar(
                    title: new Text("开图")
                    ),
                body: new Column(

                    children: new List<Widget>()
                    {
                        new Stack(
                            children:new List<Widget>()
                            {
                                new TabBar(
                                    tabs:ListConfig.tabList,
                                    labelColor:Colors.black54, 
                                    isScrollable:true,
                                    indicator:new BoxDecoration(color:Colors.blueGrey),
                                    indicatorPadding:EdgeInsets.only(top:20),
                                    controller:tabController
                                    ),
                                new Positioned(
                                    left:10,
                                    child:new Text("")
                                    )
                            }
                            ),
                        new Expanded(
                            child:new Container(
                                decoration:new BoxDecoration(color: Colors.blueGrey),
                                child: new TabBarView(
                                    controller:tabController,
                                    children:new List<Widget>()
                                    {
                                        new InsideView(),
                                        new OutsideView()
                                    }
                                    )
                                )
                            )
                    }
                    ),
                bottomNavigationBar: BuildNavigationBar(currentIndex,index=>setState(()=>currentIndex=index))
                )
            );
    }
    private BottomNavigationBar BuildNavigationBar(int index,ValueChanged<int> onTap)
    {
        return new BottomNavigationBar(
            items: BuildNavigationItemList(ListConfig.itemTitleList, ListConfig.itemIconList),
            type:BottomNavigationBarType.fix,
            currentIndex:index,
            onTap: onTap,
            selectedItemColor:Colors.blue,
            unselectedItemColor:Colors.grey
            );
    }
    private List<BottomNavigationBarItem> BuildNavigationItemList(List<string> titleList,List<IconData> iconsList)
    {

        List<BottomNavigationBarItem> temp = new List<BottomNavigationBarItem>();
        titleList.ForEach(item =>
        {
            var index = titleList.IndexOf(item);
            temp.Add(BuildNavigationItem(item, iconsList[index]));
        });
        return temp;
    }
    private BottomNavigationBarItem BuildNavigationItem(string title,IconData icons)
    {
        float size = 25;

        return new BottomNavigationBarItem(
            title: new Text(title),
            icon: new Icon(icon: icons, size: size)
            );
    }


    public Ticker createTicker(TickerCallback onTick)
    {
        return new Ticker(onTick);
    }

}



 