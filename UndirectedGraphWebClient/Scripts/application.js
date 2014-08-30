var redraw;
var height = screen.height - screen.height * 15 / 100;
var width = screen.width - screen.width * 15 / 100;

/* only do all this when document has finished loading (needed for RaphaelJS */
window.onload = function () {

    WS.INodeWS.FindAllNodes(cbRenderNodes, cbError);

};

function cbRenderNodes(result) {
    contentDiv = document.getElementById("content");
    results = "Number of nodes: " + result.length + "<br/>";
    contentDiv.innerHTML = contentDiv.innerHTML + results;

    var g = new Graph();
    // draw nodes
    for (i = 0 ; i < result.length; i++) {

        g.addNode(result[i].ID, { label: result[i].Label })

    }

    // draw all edges
    for (i = 0 ; i < result.length; i++) {

        for (j = 0; j < result[i].GraphEdges.length; j++) {
            g.addEdge(result[i].GraphEdges[j].ID, result[i].GraphEdges[j].RelatedID)
        }
    }


    /* layout the graph using the Spring layout implementation */
    var layouter = new Graph.Layout.Spring(g);
    layouter.layout();

    /* draw the graph using the RaphaelJS draw implementation */
    var renderer = new Graph.Renderer.Raphael('canvas', g, width, height);
    renderer.draw();

    redraw = function () {
        layouter.layout();
        renderer.draw();
    };

}

function cbError() {
    alert("Error!");
}