### c#窗体小游戏简介
#### 提示：此小项目是刚开始学习winform与数据库时写的。
#### 缺点：
<br>
1：没有使用三层架构，使得代码很乱。<br>
2：没有使用c#面向对象的特性，多了很多不必要重复的代码。<br>
3：没用注意命名规范，导致很多变量名，函数名，窗体名很杂乱。<br>
4：因为用的是本地服务器（数据库），导致没办法在别的电脑上运行。<br>

# 各个窗体介绍<br>
### 界面图示

![](https://github.com/rmxob/aoligei/raw/master/picture/form1.jpg)<br>

这个界面左上角显示的是人物的一些信息，包括等级，血量，攻击力，金钱数量等。<br>
#### 右边
##### （1）探险 & 技能测试
刚开始初衷是为了做一个文字版的游戏，但是被同学无情嘲讽之后，探险这块做完一小部分之后就不做了。主要的功能就是能选择怪物进行战斗。战斗的数据都是文字。<br>

![](https://github.com/rmxob/aoligei/raw/master/picture/atack.jpg)<br>

技能测试跟探险的界面差的不多，但是技能测试能选择怪物进行单独的战斗（回合制），就是你打我一下，我打你一下。人物有四个技能可以使用，每个技能有不同的特效。如下图所示<br>

![](https://github.com/rmxob/aoligei/raw/master/picture/attacking.jpg)<br>

##### （2）背包
背包界面就是玩家打完怪物之后掉落的东西，有一些回血，或者增加属性的药能够使用。

![](https://github.com/rmxob/aoligei/raw/master/picture/bag.jpg)<br>

##### (3)商店

![](https://github.com/rmxob/aoligei/raw/master/picture/shop.jpg)<br>

商店能够买一些增加属性的药。当然要有足够的金钱才行。

### 总结
这个程序还或多或少存在一些bug，就不在改了。因为c#窗体应用在以后的就业要求的不多。如果这个程序对你有所帮助，那挺好的。
若没帮助，看个乐呵就好。

没毛病，奥利给！
