require 'nokogiri'
require 'fileutils'

#
# Intermediate representation of the migrated pages
pages = []

#
# I exported my pages by year to avoid php timeouts. Set this to the appropriate year stub
year_month = "2016-01-"
day = 1

#
# Read the export, parse the document for 'page' elements
bw_cc5 = Nokogiri::XML(File.open("/home/rion/tmp/concrete5_migration/2016-export.xml"))
bw_pages = bw_cc5.child.element_children
bw_pages.children.each do |child|
  #puts child.attribute("name")

  page_content = ""
  child.element_children.each do |element|

    # Skip anything that is not a content area
    if element.name != "area"
      next
    end

    # Skip anything that is not blog post content
    if element.attribute("name").to_s != "Main" && element.attribute("name").to_s != "Blog Post More"
      next
    end

    #puts "==#{element.attribute('name')}=="

    # Each area could consist of multiple 'record' elements with 'content' sub-elements. I need to parse through
    # all of them to fill out the page
    area_content_blocks = element.xpath(".//content")
    area_content_blocks.each do |content|

      # Add a Jekyll hint that this is part of the 'post preview', only if the content was a part of the preview on
      # the Concrete5 version of the site
      if element.attribute("name").to_s == "Main"
        # 'Main' should *ALWAYS* appear before any other content blocks!
        page_content = "#{content.text}\r\n<!--more-->" + page_content
      else
        page_content = page_content + "\r\n" + content.text
      end
    end
  end

  #
  # Fix Content to account for exported images (hardcoded to /assets/images-cc5)
  page_content = page_content.gsub(/{ccm:export:image:([-.a-zA-Z0-9_!~]+\.[a-zA-Z]+)}/, '/assets/images-cc5/\1')

  #
  # Fix Content to account for intra-site page links (hardcoded to /blog/m/<blah> for migrated pages)
  page_content = page_content.gsub(/{ccm:export:page:\/blog\/([-.a-zA-Z0-9_!~]+)}/, '/blog/m/\1')

  #
  # Fix direct links to attachments (from {CCM:BASE_URL}/attachments to {{ site.url }}/attachments-cc5)
  page_content = page_content.gsub(/{CCM:BASE_URL}\/attachments/, '{{ site.url }}/attachments-cc5')

  #
  # Fix links to the site root
  page_content = page_content.gsub(/{CCM:BASE_URL}/, '{{ site.url }}')

  #
  # Fix links to the About page
  page_content = page_content.gsub(/{ccm:export:page:\/about}/, '{{ site.url }}/about')

  page = {}
  page[:title] = child.attribute("name").to_s
  page[:link_stub] = child.attribute("path").to_s.split("/")[2]
  page[:categories] = "blog"
  page[:layout] = "post"
  page[:date] = year_month + day.to_s.rjust(2, '0')
  page[:content] = page_content
  page[:excerpt_separator] = "<!--more-->"

  pages.push(page)

  day = day + 1
end

puts pages.count

#
# Generate a post for each page
pages.each do |page|
  post_content = ""
  # Add the YAML block to the top of the page (with a /r/n at the end)
  # Needs to contain:
  #   layout
  #   title
  #   date
  #   categories
  #   permalink
  post_content = post_content + "---\r\n"
  post_content = post_content + "layout: #{page[:layout]}\r\n"
  post_content = post_content + "title: \"#{page[:title]}\"\r\n"
  post_content = post_content + "date: #{page[:date]}\r\n"
  post_content = post_content + "categories: #{page[:categories]}\r\n"
  post_content = post_content + "excerpt_separator: #{page[:excerpt_separator]}\r\n"
  post_content = post_content + "permalink: /blog/m/#{page[:link_stub]}\r\n"
  post_content = post_content + "---\r\n"

  #
  # Add the page content
  post_content = post_content + page[:content]

  #
  # Write out the post
  File.write("posts/#{page[:date]}-#{page[:link_stub]}.html", post_content)

end