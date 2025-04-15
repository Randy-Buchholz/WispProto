# Wisp

Wisp is an alternative approach to software development.

Wisp was developed with the needs of the business application developer in mind.  
Wisp is not designed to support public-facing sites with millions of anonymous users and thousands of transactions per second. Nor is it designed for scientific computing performing millions of computations per second.  
Wisp is designed for line-of-business applications and high-value users promoted from public sites.  
For example, when a random browser adds items to a cart on a high-volume public site, the state/value changes from an advertising cost to a potential sale.  
Wisp changes this interaction from a generic experience to a custom experience.

---

## Key Areas

### Wisp Nodes
- **Object-Oriented HTML**: Embrace HTML as objects rather than static tags for increased clarity and flexibility.
- **Point-to-Point Connections**: Streamline communication and data flow between application components.

### Virtual Source Files
- **Code Modeling**: Simplify application architecture by organizing code as composable models.  
- **JIT Composition**: Just-In-Time (JIT) composition dynamically constructs these models when needed.  
- **Lean Manufacturing Approach**: Adopt principles inspired by lean manufacturing to minimize waste and maximize development efficiency.

---

## Tags Aren't Real

Browsers don't use HTML/CSS files or tags—they read them and discard them.  
Tags, HTML, and CSS files are parsed into objects, and it is these objects that browsers use.  
To support legacy approaches and debugging, browsers generate a tag-oriented interface over these objects.  
Through this interface, developers can locate a tag and, from this tag, locate the object.

CSS is similar. CSS is a notation used to alter `style` properties of element objects.

---

### How Browser Parsing Works

The sequencing may vary, but the core functionality works this way:  
When a browser gets an HTML file, it looks at the tags in the file. When it encounters a tag it knows (e.g., `<label>`), it finds the corresponding class (`HTMLLabelElement`). It then creates an instance of this object by calling a parameterless constructor on the class and adds the object to the DOM.  
Any attributes or content associated with the tag are then applied to the object.  

If it encounters a tag it doesn't know, it doesn't really care—it creates an instance of `HTMLUnknownElement` and adds that to the DOM.  
When it encounters a `<style>` tag (or reads a CSS file), it builds (read-only) dictionaries from the contents.  
The value parts of these dictionaries contain strings that represent property values. These values are associated with properties of a "Style object" instance on elements.  
Dictionary entries can be associated with element objects in three ways: tag matching, `class` attribute, or positional (cascade).  

This parsing process creates "static" structures for elements and "styles." The "Viewer" component of a browser displays these structures.  
Browsers are like viewers that support Macros. (e.g., a PDF Viewer). All `HTMLElement`s derive from `EventTarget` and can trigger the execution of these script macros.  

The interpreter that supports macro execution also supports an Event Loop. This provides the capability to move from an element-event-driven model to a "program model"—code can be composed into units and scheduled on the event loop.  
The programming model allows elements to be dynamically created, modified, or removed from the DOM. Their properties can be updated programmatically. Elements can be altered and "styled" dynamically using direct property assignment or applying existing CSS. But CSS itself cannot be altered—the parsed CSS remains static and immutable.

---

## Custom Elements and Constructable Style Sheets

Custom Elements bring pure object-oriented programming (OO) into the web development paradigm.  
Unlike traditional HTML tags that rely on parameterless constructors, Custom Elements can be instantiated directly via `new CustomElement(params)`.  
This allows developers to pass parameters during object creation, enabling dynamic, context-specific initialization—a significant departure from the static behavior of tags.

Constructable Style Sheets complement this shift by introducing programmatic control over styling, eliminating the need for static CSS files.  
Through JavaScript, styles can be dynamically created, attached, modified, and even scoped to specific elements or components.  
This empowers developers to maintain full control over the visual presentation of elements without being constrained by immutable, pre-parsed CSS definitions.  

Together, these technologies are foundational to Wisp's CES architecture, unlocking a new level of flexibility:
- **Pure OO Design**: Construct web pages entirely through objects, encapsulating structure and logic together.  
- **Dynamic Styling**: Adapt styles in real-time to match programmatic changes.  
- **Enhanced Modularity**: Eliminate the reliance on static HTML and CSS, simplifying development workflows.

---

## Taxels vs Document Elements

HTML defines a set of "Document Elements." These elements are designed around the component parts of a traditional document.  
But we aren't creating traditional documents in most modern web applications anymore. Instead, we're building interactive, data-driven interfaces and applications that serve specific functions—such as managing business workflows, displaying dynamic content, or supporting rich user interactions.  
Yet, the core architecture of the web forces us to shoehorn these applications into a document-based model. Developers must continuously map their data objects and business logic onto elements originally designed for paragraphs, lists, and headers—structures meant to represent static content rather than the dynamic, object-driven models that now dominate application development.  

This mismatch leads to inefficiencies and complexity. Developers often have to retrofit document elements with layers of scripting and styling to make them behave like business objects. Meanwhile, the underlying structure—the HTML—remains an artifact of its document-oriented origins, requiring workarounds to represent the interactive, stateful components of modern applications.

Taxels are custom elements aligned with business entities and objects—Taxonomic Elements. In a nutshell, with Taxels, the rendered HTML changes from things like this:

```html
<!-- Context -->
<!-- A basic form for gathering user contact details -->
<div class="container">
   <div class="row">
      <div class="person-name">
         <input type="text" class="input-field name-first" placeholder="First Name" />
         <input type="text" class="input-field name-middle" placeholder="Middle Name" />
         <input type="text" class="input-field name-last" placeholder="Last Name" />
      </div>
      <div class="street-address">
         <input type="text" class="input-field street-number" placeholder="Street Number" />
         <input type="text" class="input-field street-road" placeholder="Street Name" />
         <input type="text" class="input-field street-unit" placeholder="Unit/Apt Number" />
      </div>
   </div>
</div>
```
to this:

```html
<person-contact>
  <person-name>
    <name-first></name-first>
    <name-middle></name-middle>
    <name-last></name-last>
  </person-name>
  <street-address>
    <street-number></street-number>
    <street-road></street-road>
    <street-unit></street-unit>
  </street-address>
</person-contact>

```
By using Taxels, developers can construct cleaner, domain-driven interfaces while reducing the cognitive overhead of mapping business logic to outdated document structures.

This repo demonstrates how Wisp applies the CES architecture through practical examples and use cases. It showcases the transition from traditional document-oriented structures to business-object-aligned Taxels, emphasizing semantic clarity and dynamic styling capabilities. By leveraging Custom Elements and Constructable Style Sheets, Wisp provides a streamlined, object-oriented approach to building modern web applications. Explore the code to see how these principles come together to enhance development efficiency and adaptability.
