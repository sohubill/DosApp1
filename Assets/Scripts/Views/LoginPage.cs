
using System;
using System.Collections.Generic;
using UIWidgets.Runtime.material;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

public class LoginPage : StatefulWidget
{
    public override State createState()
    {
        return new LoginPageState();
    }
}
public class LoginPageState : State<LoginPage>
{
    private TextEditingController nameController = new TextEditingController();
    private TextEditingController passwordController = new TextEditingController();
    TextStyle inputStyle = new TextStyle(fontSize: 25, color: Colors.black);
    bool obscureText = true;
    public override void initState()
    {
        base.initState();
        nameController.addListener(() => { setState(); });
        passwordController.addListener(() => { setState(); });
    }
    public override Widget build(BuildContext context)
    {
        return new MaterialApp(
            theme: new ThemeData(primaryColor: Colors.blueGrey),
            home: new Scaffold(
                body: new Container(
                    margin: EdgeInsets.all(0),
                    decoration: new BoxDecoration(
                        //image: //添加背景图片
                        ),
                    child: new Align(
                        alignment: Alignment.center,
                        child: new SizedBox(
                        width: 400,
                        height: 400,
                        child: new Column(
                            //mainAxisAlignment:Unity.UIWidgets.rendering.MainAxisAlignment.center,
                            crossAxisAlignment: Unity.UIWidgets.rendering.CrossAxisAlignment.start,
                            children: new List<Widget>()
                            {
                                 new Text(
                                    data:"登录",
                                    style:new TextStyle(fontSize:40)
                                    ),
                                BuildNameTextField(),
                                BuildPasswordTextField(),
                                BuildLoginButton(context)
                            }
                        )
                        )
                        )
                    )
                )
            );
    }
    public override void dispose()
    {
        base.dispose();
        nameController.removeListener(() => setState());
        passwordController.removeListener(() => { setState(); });
    }

    TextField BuildNameTextField()
    {
        return new TextField(
          controller: nameController,
          style: inputStyle,
          decoration: new InputDecoration(
            labelText: "账号",
            suffixIcon: new GestureDetector(
                onTap: () =>
                {
                    nameController.clear();
                },
            child: new Icon(nameController.text.Length > 0 ? Icons.clear : null)
            )
            ),
          maxLines: 1
          );
    }

    private TextField BuildPasswordTextField()
    {
        return new TextField(
            controller: passwordController,
            style: inputStyle,
            decoration: new InputDecoration(
                labelText: "密码",
                suffixIcon: new GestureDetector(
                    onTap: () =>
                     {
                         setState(() =>
                         {
                             obscureText = !obscureText;
                         });
                     },
                    child: new Icon(obscureText ? Icons.visibility_off : Icons.visibility)
                    )
                ),
            maxLines: 1,
            obscureText: obscureText
            );
    }
    private Align BuildLoginButton(BuildContext context)
    {
        return new Align(
            child:new Container(
                margin:EdgeInsets.only(top:20),
                child: new SizedBox(
                    height: 45.0f,
                    width: 270.0f,
                    child: new RaisedButton(
                    child: new Text(
                        data: "登录",
                        style: Theme.of(context).primaryTextTheme.headline
                        ),
                        color: Colors.black,
                        shape: new StadiumBorder(side: new BorderSide(width:2))
                        )
                    )
                )     
            );
    }
}
