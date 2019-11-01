using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;
using Image = Unity.UIWidgets.widgets.Image;

public class ItemView : StatefulWidget
{
    public readonly Action<int> onTap;
    public readonly Color selectedColor;
    public readonly string title;
    public readonly bool selected = false;
    public readonly int index;
    public readonly int currentIndex;

    public override State createState()
    {
        return new ItemViewState();
    }
    public ItemView(string title, int index, int currentIndex, Color selectedColor, Action<int> onTap)
    {
        this.onTap = onTap;
        this.selectedColor = selectedColor;
        this.title = title;
        this.index = index;
        this.currentIndex = currentIndex;
    }
}

class ItemViewState:State<ItemView>
{
    private Action<int> onTap;
    private Color selectedColor;
    private string title;
    private bool selected = false;
    private int index;
    private int currentIndex;

    void OnTap()
    {
        onTap?.Invoke(index);
        setState();
        
    }

    public override Widget build(BuildContext context)
    {
        onTap = this.widget.onTap;
        selectedColor = this.widget.selectedColor;
        title = this.widget.title;
        selected = this.widget.selected;
        index = this.widget.index;
        currentIndex = this.widget.currentIndex;
        selected = currentIndex == index;
        float width = Screen.width * 0.8f - 60;
        return new GestureDetector(
            child: new Container(
                width: width,
                color: selected ? selectedColor : null,
                child: new Card(
                    child: new ListTile(
                        title: Image.asset("LiftModel/" + title),
                        subtitle: new Text(title, textAlign: TextAlign.center)
                        )
                    )
                ),
            onTap: () => OnTap()
            )
            ;
    }

}
