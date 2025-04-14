# Wisp Example
Wisp is an Object-Oriented approach to web development.  
Wisp uses Custom Elements and Constructable Style Sheets to define "Elms" and "Sheets".  

Tags/html and css files are not used. Instead, elements are created directly as "Objects with GUIs".  
Custom Elements are created from classes:
```
class MyElement extends HTMLElemnt{
   static { customElement.define("my-element", this); }
} 
```
Unlike built-in elements, custom element constructors are not private.  
You can "new" custom elements:

`const myElm = new MyElement(parameters);`

Styling uses "Stylettes" - fragments of css and "Custom Rules":

```
customRules = new CSSStyleSheet();
customRules.define("my-element", `position:relative;background-color:blue;`);
```

Taxels are Taxanomic Elements - Object elements aligned with businss objects and not display nodes.  
Components/compound elements are constructed like any other objects:
```
personContact = new PersonContact();
personName = new PersonName();
streetAddress = new StreetAddress();
personContact.appendChild(personName);
personContact.appendChild(streetAddress);
```

WHen rendered to tags, the html looks like this:
```
<person-contact>
  <person-name></person-name>
  <street-address></street-address>
</person-contact>
```

Wisp has many aspects and feeatures to simplify working with Elms and Sheets.  
There are tools and development management processes.  
Wisp is not a "framework". It is an approach that developers and organizations can utilize to create their own frameworks.  

This repo is a simple example of using Wisp on a "static" web page.  
Normally Wisp uses WebSockets fora fully dynamic real-time experience. A sockets demo is in the works.

