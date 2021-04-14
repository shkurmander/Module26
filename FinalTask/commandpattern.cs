
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25
26
27
28
29
30
31
32
33
34
35
36
37
38
39
40
41
42
43
44
45
46
47
48
49
50
51
52
53
54
55
56
57
58
59
60
61
62
63
64
65
66
67
68
69
70
71
72
73
74
75
76
77
78
79
80
81
82
83
84
85
86
87
88
89
90
91
92
93
94
95
96
97
98
99
100
101
102
103
104
105
106
107
108
109
110
111
112
113
114
115
116
117
118
119
120
121
122
123
124
125
126
127
128
129
130
131
132
133
134
135
136
137
138
139
140
141
142
143
144
145
146
147
148
149
150
151
152
153
154
class Program
{
    static void Main(string[] args)
    {
        Programmer programmer = new Programmer();
        Tester tester = new Tester();
        Marketolog marketolog = new Marketolog();

        List<ICommand> commands = new List<ICommand>
        {
            new CodeCommand(programmer),
            new TestCommand(tester),
            new AdvertizeCommand(marketolog)
        };
        Manager manager = new Manager();
        manager.SetCommand(new MacroCommand(commands));
        manager.StartProject();
        manager.StopProject();

        Console.Read();
    }
}
interface ICommand
{
    void Execute();
    void Undo();
}
// Класс макрокоманды
class MacroCommand : ICommand
{
    List<ICommand> commands;
    public MacroCommand(List<ICommand> coms)
    {
        commands = coms;
    }
    public void Execute()
    {
        foreach (ICommand c in commands)
            c.Execute();
    }

    public void Undo()
    {
        foreach (ICommand c in commands)
            c.Undo();
    }
}

class Programmer
{
    public void StartCoding()
    {
        Console.WriteLine("Программист начинает писать код");
    }
    public void StopCoding()
    {
        Console.WriteLine("Программист завершает писать код");
    }
}

class Tester
{
    public void StartTest()
    {
        Console.WriteLine("Тестировщик начинает тестирование");
    }
    public void StopTest()
    {
        Console.WriteLine("Тестировщик завершает тестирование");
    }
}

class Marketolog
{
    public void StartAdvertize()
    {
        Console.WriteLine("Маркетолог начинает рекламировать продукт");
    }
    public void StopAdvertize()
    {
        Console.WriteLine("Маркетолог прекращает рекламную кампанию");
    }
}

class CodeCommand : ICommand
{
    Programmer programmer;
    public CodeCommand(Programmer p)
    {
        programmer = p;
    }
    public void Execute()
    {
        programmer.StartCoding();
    }
    public void Undo()
    {
        programmer.StopCoding();
    }
}

class TestCommand : ICommand
{
    Tester tester;
    public TestCommand(Tester t)
    {
        tester = t;
    }
    public void Execute()
    {
        tester.StartTest();
    }
    public void Undo()
    {
        tester.StopTest();
    }
}

class AdvertizeCommand : ICommand
{
    Marketolog marketolog;
    public AdvertizeCommand(Marketolog m)
    {
        marketolog = m;
    }
    public void Execute()
    {
        marketolog.StartAdvertize();
    }

    public void Undo()
    {
        marketolog.StopAdvertize();
    }
}

class Manager
{
    ICommand command;
    public void SetCommand(ICommand com)
    {
        command = com;
    }
    public void StartProject()
    {
        if (command != null)
            command.Execute();
    }
    public void StopProject()
    {
        if (command != null)
            command.Undo();
    }
}