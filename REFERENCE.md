# Reference

- <a href="#initializing-a-new-document">Initializing a new document</a>
  - <a href="#master-pages">Master pages</a>
  - <a href="#regions">Regions</a>
- <a href="#page-sequences">Page sequences</a>
  - <a href="#flows">Flows</a>
  - <a href="#static-content">Static content</a>
- <a href="#content">Content</a>
  - <a href="#lists">Lists</a>


## Initializing a new document

The actual PDF document is in this package represented by the `FoDocument` class. You can create a new instance of it as:

```c#
// Initialize a new document
FoDocument document = new FoDocument();
```

If you're using IBEX for generating the PDF, you can also specify a number of extra properties on the document:

```c#
document.Properties = new IbexProperties {
    Author = "Me",
    Title = "Test PDF document",
    Subject = "Test PDF document",
    Creator = "Skybrud.Pdf",
    Keywords = new []{ "hello", "world" }
};
```

### Master pages

As part of setting up a new document, you should also add at least one master page. A master page can be thought of as a template for your pages. You can add as many master pages as you need.

XSL-FO supports a few different master page types, but `fo:simple-master-page` is probably the only one you'll ever need.

For the master page, you specify a name as the width of the height of the page. For instance in the example below, I've created a new master page for an A4 portrait format. The master page also defines the margins of the page.

```c#
// Initialize the "Master" master page
FoSimpleMasterPage master = new FoSimpleMasterPage("Master", "210mm", "297mm") {
    MarginTop = "1cm",
    MarginBottom = "0.5cm",
    MarginRight = "1.8cm",
    MarginLeft = "1.8cm"
};

// Add the master page to the document
document.LayoutMasterSet.Add(master);
```

### Regions

A `fo:simple-master-page` consists of one or more regions. Your master page should at least have a "body" region, which is used for the main content of each page. But you can also define `before` and `after` regions which can be used for headers and footer respectively. When adding content, you can refer to a region by it's name.

```c#
// Add a new fo:region-body (required)
master.Regions.Add(new FoRegionBody {
    MarginTop = "1cm",
    MarginBottom = "0cm"
});

// Add a new fo:region-before (optional)
master.Regions.Add(new FoRegionBefore {
    RegionName = "header",
    Extent = "0cm",
    MarginBottom = "35px"
});

// Add a new fo:region-after (optional)
master.Regions.Add(new FoRegionAfter {
    RegionName = "footer",
    Extent = "35px",
});
```

You can use the `MarginTop`, `MarginBottom` and `Extent` properties to control the size of each region.

## Page sequences

To add any content to the PDF document, you must add one or more page sequences (as `fo:page-sequence` elements). A page sequence is based on a master page, so pages in a given page sequence follows the size of it's master page.

### Flows

In XSL-FO you don't actually add individual pages - instead you add content to a `fo:flow` element, which represents the main content of the pages. Setting up both the `fo:page-sequence` and `fo:flow` elements could look like this:

```c#
// Initialize a new flow based on the body region
flow = new FoFlow("xsl-region-body");

// Initialize a new page based on the flow
FoPageSequence page = new FoPageSequence("Master", "Master", flow);

// Append the page sequence to the document
document.PageSequences.Add(page);
```

### Static content

The `fo:region-before` element can serve as the header of your pages, and as such you can add it to your page sequence like:

```c#
// Initialize a new static content for the header (before region)
FoStaticContent header = new FoStaticContent("header");
page.StaticContent.Add(header);
```

On the other hand, the `fo:region-after` element represents can serve as the footer of your pages:

```c#
// Initialize a new static content for the footer (after region)
FoStaticContent footer = new FoStaticContent("footer");
page.StaticContent.Add(footer);
```

In both cases, the argument for the `FoStaticContent` constructor refers to the names you specified for your regions of the master page.

## Content

Once you have configured a page sequence, you can start adding content to either it's `fo:flow` element or one of the `fo:static-content` elements representing a region.

Typically your would start out with either a `fo:block-container` element or a `fo:block` element:

```c#
flow.Add(new FoBlock("Hello World"));
```

### Lists

You can create lists using the `fo:list-block` element for the entire list, and `fo:list-item` elements for each item. The `fo:list-item` element then consists of one `fo:list-item-label` element and one `fo:list-item-body` element:

```c#
// Create a new list block
FoListBlock list = new FoListBlock();
parent.Add(list);

// Iterate through each item
foreach (var item in items) {

    // Initialize a new list item
    FoListItem li = new FoListItem {
        Label = new FoListItemLabel(),
        Body = new FoListItemBody()
    };

    // Add the list item to the list block
    list.Add(li);

}
```

You can add any content you wish to both the `fo:list-item-label` the `fo:list-item-body`. For the label, it would typically be sufficient to just add a hypen or similar:

```c#
// Use a simple hyphen for the label
li.Label.Add(new FoBlock("-"));
```

You could also create your own `int` variable in C# and then increment it for each item to create a numbered list instead. For the item body, we could add a new `fo:block` with the name of the item, and show it in bold:

```c#
li.Body.Add(new FoBlock(feature.FeatureName) {
    FontWeight = FoFontWeight.Bold
});
```
























