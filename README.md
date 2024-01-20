### Csharp-Utils

Some of my old c# code that i found on my pc and decide to share it 

### Input value usage

```c
string value = "Document 1";
if (Tmp.InputBox("New document", "New document name:", ref value) == DialogResult.OK)
{
  myDocument.Name = value;
}
```
