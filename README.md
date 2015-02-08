##Yuyingjian.Validaiton
A simple validation library for .NET

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

//...
```