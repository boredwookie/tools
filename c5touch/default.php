<?php
defined('C5_EXECUTE') or die(_("Access Denied."));
$this->inc('elements/header.php'); ?>

<div class="content" id="content<?php echo md5($_SERVER['REQUEST_URI']); ?>">

<?php 
$a = new Area('Main Header');
$blocks = $a->getTotalBlocksInArea($c);
if ($blocks > 0 || $c->isEditMode()) { ?>
	<div class="post">
	<div id="content-header">
	<?php $a->display($c); ?>
	</div>
	</div>
<?php } else if ($blocks == 0 && (!$c->isEditMode()) && $c->getCollectionTypeHandle() == 'post') { ?>
	<div class="post">
	<div id="content-header">
	<h1><?php echo $c->getCollectionName()?></h1>
	</div>
	</div>
<?php } ?>

<div class="post">
<?php $a = new Area('Main');
$a->display($c); ?>
</div>


<?php $a = new Area('Main Post');
$blocks = $a->getTotalBlocksInArea($c);

if ($blocks > 0 || $c->isEditMode()) { ?>
<div class="post">
<div id="<?php if ($c->getCollectionTypeHandle() == 'post') { ?>content-main-post<?php } ?>">
<?php $a->display($c); ?>
</div>
</div>
<?php } ?>

</div>

