##YuYingjian.Validaiton
A simple validation library for .NET

visual studio 2013编写 .net framework 4.5.1

要在低版本中使用，自己想办法-_-

###Example
```cs
using YuYingjian.Validation;
using YuYingjian.Validation.Validator;

//...

var vc = "6".IsInt().IsInRange(1, 10).Msg("1~10之间的整数");
if(vc.IsValid){
  logger.info("验证通过");
}else{
  logger.info(vc.Message);
}

".net45yyj".IsLength(6, 20).IsPassword().Msg("6~20位大小写英文字母数字英文标点符号");

//具体的扩展方法请看Validator文件夹下的源码注释
```

###Strings Only
This library validates strings or any type can convert to string only.

###NuGet
PM> Install-Package YuYingjian.Validation