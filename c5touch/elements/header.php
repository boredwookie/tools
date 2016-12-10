<?php defined('C5_EXECUTE') or die(_("Access Denied.")); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
        "http://www.w3.org/TR/2000/REC-xhtml1-20000126/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
	
<!-- Site Header Content //-->
<link rel="stylesheet" media="screen" type="text/css" href="<?php echo $this->getThemePath()?>/main.css" />
<link rel="stylesheet" media="screen" type="text/css" href="<?php echo $this->getThemePath()?>/site.css" />
<meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no;" />

<?php Loader::element('header_required'); ?>

</head>
<body class="classic-wptouch-bg">

<a style="position: absolute; z-index: 20; top: 17px; right: 12px; font-size: 12px; color: #fff" href="#footersearch"><?php echo t('Search')?></a>

<div id="headerbar">
	<div id="headerbar-title">
		<!-- This fetches the admin selection logo icon for the header, which is also the bookmark icon -->
		<img id="logo-icon" src="<?php echo $this->getThemePath()?>/images/header_icon.png" alt="<?php echo SITE?>" />
		<a href="<?php echo DIR_REL?>/"><?php print SITE; ?></a>
	</div>
</div>