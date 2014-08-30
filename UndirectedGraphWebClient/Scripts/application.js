$(function(){ // on dom ready

    WS.INodeWS.FindAllNodes(cbRenderNodes, cbError);

    
  
}); // on dom ready


function cbRenderNodes(result) {

    contentDiv = document.getElementById("content");
    results = "Number of nodes: " + result.length + "<br/>";
    contentDiv.innerHTML = contentDiv.innerHTML + results;

    var nodes = [];
    for (var i = 0; i < result.length; i++) {
        nodes.push({
            group: 'nodes',
            data: {
                id: result[i].ID,
                name: result[i].Label
            }
        });
    }

    var edges = [];
    for (var i = 0; i < result.length; i++) {
        for (var j = 0; j < result[i].GraphEdges.length; j++) {

            if (!findRepeatedEdge(edges, result[i].GraphEdges[j].ID, result[i].GraphEdges[j].RelatedID)) {

                edges.push({
                    group: 'edges',
                    data: {
                        source: result[i].GraphEdges[j].ID,
                        target: result[i].GraphEdges[j].RelatedID
                    }
                });
            }
        }
    }
    
    
    var cy = cytoscape({
        container: $('#cy')[0],

        style: cytoscape.stylesheet()
          .selector('node')
            .css({
                'content': 'data(name)',
                'text-valign': 'center',
                'color': '#34495e',
                'width': '100px',
                'height': '100px',
                'border-width': '2px',
                'border-color': '#34495e',
                'background-color': '#ecf0f1',
            })
          .selector('edge')
            .css({
                'line-color': '#bdc3c7' 
            })
          .selector('.selected')
            .css({
                'background-color': '#e74c3c',
            }),


        elements: {
            nodes: nodes,
            edges: edges
        },

        layout: {
            name: 'random',
            padding: 30
        },

        ready: function () {
            window.cy = this;

            cy.userZoomingEnabled(false);
            cy.elements().unselectify();

            cy.on('tap', 'node', function (e) {

                var node = e.cyTarget;
                node.toggleClass('selected');

                if (cy.$('.selected').length > 2) {
                    alert("You can only select two nodes");
                    cy.elements().removeClass("selected");
                }

            });
        }
    });

}

function cbError() {
    alert("Error!");
}

function findRepeatedEdge(edges, id, relatedId) {

    for (var i = 0; i < edges.length; i++) {
        if (edges[i].data.source == relatedId && edges[i].data.target == id) {
            return true;
        }
    }
    return false;
}

function redrawGraph() {
    location.reload();
}
