// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#startGame').on('click', ev => {
    $('#map-select').removeClass('hidden');
    $(ev.currentTarget).hide();
});

$('.thumbnail').on('click', ev => {
    // Get the current map
    let mapName = ev.currentTarget.getAttribute('data-map');
    let sourceThumb = ev.currentTarget;
    let selectedMapElement = document.getElementById('selectedMap');
    
    // Set the selected map image (copy from source)
    selectedMapElement.setAttribute('src', ev.currentTarget.getAttribute('src'));
    selectedMapElement.setAttribute('alt', ev.currentTarget.getAttribute('alt'));
    document.getElementById('selectedMapInput').value = mapName;
    
    // Set the map name
    document.getElementById('selectedMapName').innerText = mapName;
    
    // Show difficulty select
    $('#map-select').addClass('hidden');
    $('#difficulty-select').removeClass('hidden');
    $('#selectedMapContainer').removeClass('hidden');
})

$('#openMap').on('click', _ => {
    // Reset image container and hide it
    document.getElementById('imageToGuessContainer').style.display = 'none';
    let imageElement = document.getElementById('imageToGuess');
    imageElement.setAttribute('url', '');
    imageElement.setAttribute('alt', '');
    
    // Display map
    document.getElementById('openMapContainer').style.display = 'none';
    document.getElementById('mapDisplay').style.display = 'flex';
})