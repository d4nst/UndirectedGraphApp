UndirectedGraphApp
==================

This application lets you load an undirected graph to a database and visualize it on a thin web client. The client can also calculate the shortest path between two selected nodes.

## Input Data
The input data is provided with a set of XML files. Each file represents a single graph node in the following format:

    <node>
    	<id>XXX</id>
    	<label>Some label</label>
    	<adjacentNodes>
    		<id>YYY</id>
    		<id>ZZZ</id>
    	</adjacentNodes>
    </node>
    
- ID: a unique string identifying the node
- Label: human readable text to be displayed in UI
- Adjacent Nodes: IDs of nodes adjacent to current

Node relationships could be described in uni or bidirectional mode. Since we are operating on an undirected graph, bidirectional relationships are treated the same way as a unidirectional ones.

A sample set of input files is provided in the Input data folder located in the root directory.

## Solution components
Dependency injection has been used to keep the coupling of the components to a minimum. The components are wired in the Web Services project.

### Entity 
This project uses a Code First approach using Entity Framework. This means that there is no need to install nor configure any database to run the project. By default, Entity Framework will create a database in SQL Server Express (installed by default in Visual Studio 2010) or in [LocalDb](http://msdn.microsoft.com/en-us/library/hh510202(v=SQL.110).aspx) (installed by default in Visual Studio 2012 and 2013) if SQL Server Express is not found.

There are two entities: GraphNode and GraphEdge, each of them mapped to a table in the database with the nodes and edges information respectively.

### Repository
The Repository project implements the Repository and Unit of Work pattern to access and manipulate all the data needed for the rest of the application.

### Service
The Service project contains three components:

##### Data management
Used by the Data Loader console application. 
There are three methods available: an XML parser to parse a single file to a GraphNode entity, a method to insert an XML file to the database using the provided parser, and a method to insert all the XML files under a given directory to the database using the provided parser.

##### Front-end oriented 
Used to provide data for the web application. 
It contains just a method to retrieve all the nodes from the database. 

##### Domain specific
Used to implement a path finding algorithm. 
It contains a method that returns the shortest path between a root node and a target node using the [Breadth-first search ](http://en.wikipedia.org/wiki/Breadth-first_search) algorithm.

### Web Services
The Web Services project is a Web Service Library in charge of wiring all the components and provide the methods to be used by the console and the web applications. 

Again, the same three categories exists: Data management, Front-end oriented and Domain Specific, with the same functions as before. 

Running this project in Visual Studio would let you use the WCF Test Client to test the web services.

### Data Loader (console application)
The Data Loader project is a simple console application that lets you load a graph into the database by inserting all the XML files under the selected directory. If no directory is selected, the "Input data" directory under the project rooth path is loaded.

Every time the data is loaded, the database is cleared and the data inserted again. This is useful to re-execute over the same folder again when new node files are added or existing files removed.

### Web Client
The Web Client project is in charge of the graph visualisation. 

Nodes are drawn in a random order and can be moved around clicking and dragging them with the mouse. Nodes can be selected  by clicking on them in order to calculate the shortest path between them. When the "Calculate Shortest Path" button is clicked, all the nodes and edges between the root and target nodes are highlighted.

The [Cytoscape.js](http://cytoscape.github.io/cytoscape.js/) library has been used to simplify the UI implementation.


