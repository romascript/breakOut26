<!DOCTYPE html>
<html>
<head>
	<title>Break Out 26</title>
	<meta name="viewport" content="width=device-width">
	<link rel="icon" type="image/png" href="img/favicon/log.ico"/>
	<link type="text/css" rel="stylesheet" href="css/style.css"/>
	<link type="text/css" rel="stylesheet" href="css/yeti.min.css"/>
	<link type="text/css" rel="stylesheet" href="js/fullPage.js-master/jquery.fullPage.css" />
	<script async src="https://platform.twitter.com/widgets.js"></script>
	<script async defer src="https://buttons.github.io/buttons.js"></script>
	<script src="https://apis.google.com/js/platform.js" async defer></script>
	<script type="text/javascript" src="js/jquery-1.12.2.min.js"></script>
	<script type="text/javascript" src="js/bootstrap.min.js"></script>
	<script src="js/jquery-1.12.2.min.js"></script>
 	<script src="js/fullPage.js-master/vendors/jquery.easings.min.js"></script>
  	<script src="js/fullPage.js-master/vendors/scrolloverflow.min.js"></script>
  	<script src="js/fullPage.js-master/jquery.fullPage.min.js"></script>
  	<script src="js/index.js"></script>
</head>
<body>
	<?php include 'php_html/menu.php'; ?>
	<div id="fullpage">
		<div id="index" class="section">
			<img src="img/breakOut26.png">
			<h3>¡Bienvenidos a la web oficial del videojuego mas popular de todos los tiempos!</h3>
			<div id="navbar-social">
				<a class="twitter-share-button" href="https://twitter.com/intent/tweet?text=#IPlayBreakOut26" data-size="large">Tweet</a>
				<div class="g-follow" data-annotation="bubble" data-height="24" data-href="//plus.google.com/u/0/106277600908355414874" data-rel="author"></div>
				<div class="g-plus" data-action="share" data-height="24"></div>
			</div>
		</div>
		<div id="wiki-users" class="section">
			<center>
				<h1>WIKI Usuarios:</h1>
				<div class="tab-page"> 
					<ul class="nav nav-tabs">
						<li class="active"><a href="#home" data-toggle="tab">Sobre el juego</a></li>
					  	<li><a href="#history" data-toggle="tab">Historia</a></li>
					</ul>
					<div id="myTabContent" class="tab-content">
						<div class="tab-pane fade active in" id="home">
						  	<h2>Descripcion:</h2>
						    <p>Break Out 26 es un videojuego que utiliza realidad aumentada. Desarrollado por estudiantes de la E.T N°26 "Confederacion Suiza". Es el clasico Break Out '76 diseñado por Atari, pero adaptado al siglo XXI.</p>
						    <br>
						    <p>Las reglas y su tematica son iguales a la del original. Lo especial de este juego es la forma en la que el jugador interactua con el, ya que para mover el paddle no se necesitan las flechas del teclado, solo mover un objeto delante de una webcam para indicarle al paddle hacia que lado debe desplazarse.</p>
						</div>
						<div class="tab-pane fade" id="history">
						    <h2>¿Como surgio el juego?</h2>
						    <p>Este juego surgio a traves de la idea de un alumno de 5to-11 en la E.T N°26. Ya que en la materia "proyectos II"  era necesario presentar un proyecto. Este fue aprobado por el docente a cargo y comenzo su desarrollo.</p>
						    <h2>Primera version (1.0):</h2>
						    <p>La version 1.0 fue lanzada al mes de iniciarse el proyecto. Dicha version fue presentada oficialmente en la expo tecnica 2017 que realizo la E.T N°25 "Fray Luis Beltran".</p>
						</div>
					</div>
				</div>
			</center>
		</div>
		<div id="wiki-devs" class="section">
    		<center>
	    		<h1>WIKI Developers:</h1>
	    		<br>
	    		<div class="tab-page">
					<ul class="nav nav-tabs">
					  <li class="active"><a href="#proyecto" data-toggle="tab">Sobre el proyecto</a></li>
					  <li><a href="#tools" data-toggle="tab">Software</a></li>
					  <li><a href="#git" data-toggle="tab">Git</a></li>
					</ul>
					<div id="myTabContent" class="tab-content">
						<div class="tab-pane fade active in" id="proyecto">
							<h1>Proyecto "Open Source":</h1>
						    <p>Break Out 26 es un proyecto que adopta la forma "Open Source". Esto quiere decir que es libre y gratuito, tanto para jugadores como tambien para desarrolladores. Si usted desea contribuir con el proyecto actual o solamente quiere saber como esta programado, debe hacer click en la pestaña que dice "Git", en donde encontrara los enlaces necesarios para obtener el codigo fuente.</p>
						    <h1>Metodologia utilizada:</h1>
						    <p>Para trabajar en este proyecto utilizamos <a href="https://es.wikipedia.org/wiki/Desarrollo_%C3%A1gil_de_software" target="_blank">"Metodologias agiles de desarrollo de software"</a>. En este caso utilizamos el metodo <a href="https://es.wikipedia.org/wiki/Scrum_(desarrollo_de_software)" target="_blank">"SCRUM"</a>. De esta forma el trabajo es mucho mas rapido y organizado. Y lo mas importante es que el proyecto puede llevarse a cabo.</p>
						</div>
						<div class="tab-pane fade" id="git">
						  	<h1>Git:</h1>
						  	<p>Para descargarte el codigo fuente de nuestro proyecto deberas hacer click en el boton "Download" y seguir los siguientes pasos.</p>
						  	<a class="github-button" href="https://github.com/romascript/breakOut26/archive/master.zip" data-size="large" aria-label="Download romascript/breakOut26 on GitHub" align="center" >Download</a>
						  	<h1>Tutorial git:</h1>
						 	<iframe width="600" height="315" src="https://www.youtube.com/embed/XGSy3_Czz8k"></iframe>
						</div>
						<div class="tab-pane fade" id="tools">
							<h1>Software utilizados:</h1>
							<ul>
						    <li>
						    	<h2><a href="https://unity3d.com/es" target="_blank">Unity 5</a> & OpenCV Sharp:</h2>
						    	<p>Toda la parte grafica fue desarrollada con el motor grafico de Unity 5 de 32bits (el de 64 bits las librerias de OpenCV sharp no funcionan). Para la realidad aumentada se utilizo OpenCV Sharp (una extension del OpenCV, pero esta puede ser programada en C#).</p>
						    </li>
						    <li>
						    	<h2><a href="https://www.visualstudio.com/team-services/" target="_blank">Team Service</a>:</h2>
						    	<p>Hemos repartido las tareas a traves de un software proporcionado por Microsoft llamado "Team Service".</p>
						    </li>
						    <li>
						    	<h2><a href="https://about.gitlab.com/" target="_blank">Gitlab</a>:</h2>
						    	<p>Utilizamos los repositorios de gitlab (git) para trabajar con el versionado de software.</p>
						    </li>
						    <ul>
						</div>
					</div>
				</div>
			<center>
		</div>
		<div id="download" class="section">
			<center>
				<h1>Download:</h1>
				<div class="tab-page">
					<ul class="nav nav-tabs">
						<li class="active"><a href="#download" data-toggle="tab">Download <span class="icon-bar glyphicon glyphicon-download"/></a></li>
					</ul>
					<div id="myTabContent" class="tab-content">
						<div class="tab-pane fade active in" id="#download">
							<h1>Requisitos:</h1>
							<ul>
								<li>S.O: Windows 7,8 o superior de 32 o 64 bits.</li>
								<li>Webcam.</li>
								<li>2GB de RAM o superior.</li>
								<li>Procesador dual-core 2 Ghz o superior (ej: intel core 2 duo).</li>
								<li>Espacio disponible en el disco: 125 MB.</li>
							</ul>
							<h1>Descargar...</h1>
							<ul>
								<li>
									<h3>Exe Installer (x86，For Windows):</h3>
									<button class="btn btn-primary">Download <span class="icon-bar glyphicon glyphicon-download"/></button>
								</li>
								<li>
									<h3>Portable (For Windows, Mac & Linux):</h3>
									<button class="btn btn-primary">Download <span class="icon-bar glyphicon glyphicon-download"/></button>
								</li>
							</ul>
							<h1>Tutoriales:</h1>
							<ul>
								<li><a href="#">Manual de instalacion.</a></li>
								<li><a href="#">Manual de instrucciones.</a></li>
							</ul>
						</div>
					</div>
				</div>
			</center>
		</div>
    	<div id="devs" class="section">
	    	<center>
	    		<h1>Developers:</h1>
	    		<div id="grid">
		    		<div id="grid-one">
		    			<img class="profile-photos" src="https://scontent-eze1-1.cdninstagram.com/t51.2885-19/s150x150/18298483_297124754033392_3150919893906358272_a.jpg">
		    			<h3>Roman Pozzuto</h3>
		    			<h4>Project Leader & Developer.</h4>
		    			<a class="twitter-follow-button"
						  href="https://twitter.com/roma0k"
						  data-size="large">
						Follow @TwitterDev</a>
						<br>
						<a class="github-button" href="https://github.com/romascript" data-size="large" aria-label="Follow @romascript on GitHub">Follow @romascript</a>
		    		</div>
		    		<div id="grid-two">
		    			<img class="profile-photos" src="https://scontent-eze1-1.cdninstagram.com/t51.2885-19/s150x150/15057142_207578116352588_792044514012299264_a.jpg">
		    			<h3>Roberto Vazquez</h3>
		    			<h4>Developer.</h4><a class="twitter-follow-button"
						  href="https://twitter.com/robyaffliction"
						  data-size="large" data-show-count="true">
						Follow @TwitterDev</a>
		    		</div>
		    		<div id="grid-three">
		    			<img class="profile-photos" src="https://pbs.twimg.com/profile_images/806281643958865920/L66EHQpg_400x400.jpg">
		    			<h3>Sofia Lopez</h3>
		    			<h4>Documentary & Developer.</h4>
		    			<a class="twitter-follow-button"
						  href="https://twitter.com/sojennlopez"
						  data-size="large">
						Follow @TwitterDev</a>
		    		</div>
	    		</div>
	    	</center>
    	</div>
	</div>
</body>
</html>

