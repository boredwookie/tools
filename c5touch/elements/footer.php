<?php defined('C5_EXECUTE') or die(_("Access Denied.")); ?>

<div class="search-wrapper">
	<a name="footersearch"></a>
	<form method="get" action="<?php echo $this->url('/search')?>">
		<input type="text" name="query" class="text" value="Search..." onfocus="if (this.value == 'Search...') {this.value = ''}" />
	</form>
</div>

<div id="footer">
	<p><?php echo t('&copy %s %s', date('Y'), SITE)?></p>
	<p><?php echo t('Powered by ')?><a href="http://www.andrewembler.com/concrete5/c5touch/"><?php echo t('c5touch')?></a><?php echo t(', based on ')?><a href="http://www.bravenewcode.com/wptouch/"><?php echo t('wptouch')?></a><?php echo t('(originally for Wordpress).')?></p>
</div>


<?php Loader::element('footer_required'); ?>

</body>
</html>